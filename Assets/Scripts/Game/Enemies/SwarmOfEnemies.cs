using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Zenject;
using System.Linq;
using System;
using Random = UnityEngine.Random;

public class SwarmOfEnemies : MonoBehaviour
{
    [SerializeField] private EnemyComponent _enemyPfb;
    [SerializeField] private int _countRows;
    [SerializeField] private int _countColumn;
    [SerializeField] private float _betweenDistance;
    [SerializeField] private float _shotTimeout;

    [SerializeField] private float _moveStep = 0.5f;   
    [SerializeField] private float _moveStartTimeout = 1f;
    [SerializeField] private float _moveMinTimeout = 0.2f;    
    [SerializeField] private float _offsetFromBorder = 2f;    
    [SerializeField] private int _moveDownWithLifeEnemies = 4;    
    [SerializeField] private float _moveDownStep = 0.5f;

    public event Action OnEndEnemies;
    public event Action<Vector2> OnEnemyDead;

    private EnemyFactory _enemyFactory;
    private WorldBorders _worldBorders;
    private EnemyCounter _enemyCounter;
    private List<EnemyComponent> _enemies = new List<EnemyComponent>();
    private Timer _timer;
    private float _currentTimeoutStep;

    
    [Inject]
    public void Construct(GameWorldSettings gameWorldSettings, EnemyCounter enemyCounter)
    {
        _worldBorders = gameWorldSettings.WorldBorders;
        _enemyCounter = enemyCounter;
    }

    private void Awake()
    {
        _enemyFactory = new EnemyFactory();     
        SpawnEnemies();
    }

    private void OnEnable()
    {
        _timer = new Timer(_shotTimeout);
        _timer.OnEnd += _timer_OnEnd;
    }

    public void Play()
    {        
        _timer.Start();      
        StartCoroutine(Move());
    }


    private void _timer_OnEnd()
    {
        var canShotsEnemies = _enemies.FindAll(x=> x.isLife &&  x.CanAttack);
        
        if (canShotsEnemies.Count == 0) return;

        var r = Random.Range(0, canShotsEnemies.Count);
        canShotsEnemies[r].Attack();
        _timer.Start();
    }

    private void OnDisable()
    {
        _timer.OnEnd -= _timer_OnEnd;
    }

    private void TryClearEnemies()
    {
        if (_enemies.Count > 0)
        {
            _enemies.ForEach(x => Destroy(x.gameObject));
            _enemies.Clear();
        }
    }
    private void CountingDead(Vector2 pos)
    {        
        _enemyCounter.Add(1);
        OnEnemyDead?.Invoke(pos);
    }

    public void SpawnEnemies()
    {
        TryClearEnemies();

        var enemyScale = _enemyPfb.transform.localScale;
        float startX = 0.5f * enemyScale.x + transform.position.x - (_countColumn * enemyScale.x + (_countColumn - 1) * (_betweenDistance - enemyScale.x)) /2;         
        float startY = 0.5f * enemyScale.y + transform.position.y - (_countRows * enemyScale.y + (_countRows - 1) * (_betweenDistance - enemyScale.y)) / 2;
        
        for (int i = 0; i < _countRows; i++)
        {
            for (int j = 0; j < _countColumn; j++)
            {
                var pos = new Vector2(startX + j * _betweenDistance, startY + i * _betweenDistance);
                var enemy = _enemyFactory.Create(_enemyPfb, pos);
                enemy.Init(_worldBorders, CountingDead);
                _enemies.Add(enemy);
            }
        }
    }

    private IEnumerator Move()
    {
        if (_enemies.Count > 0)
        {
            _currentTimeoutStep = (_moveStartTimeout - _moveMinTimeout) / _enemies.Count;
        }
        else
        {
            yield return null;
        }
        
        float dir = 1;        

        while (_enemies.FindAll(x => x.isLife).Count > 0) 
        {
            var activeEnemies = _enemies.FindAll(x => x.isLife);
            var groups = activeEnemies.GroupBy(x => x.transform.position.y);
            groups = groups.OrderBy(x => x.Key);
            
            var currentTimeout = _moveMinTimeout + _currentTimeoutStep * (activeEnemies.Count - 1);
            var sordedByX = activeEnemies.OrderBy(e => e.transform.position.x);

            var leftEnemy = sordedByX.First();
            var rightEnemy = sordedByX.Last();

            foreach (var g in groups)
            {
                yield return new WaitForSeconds(currentTimeout);
                
                MoveRow(g.ToList(), dir, 0);
                
                if (leftEnemy.transform.position.x < _worldBorders.MinX + _offsetFromBorder)
                {
                    dir = 1;
                    if (activeEnemies.Count <= _moveDownWithLifeEnemies) MoveRow(g.ToList(), 0, - _moveDownStep);
                }
                else if (rightEnemy.transform.position.x > _worldBorders.MaxX - _offsetFromBorder)
                {
                    dir = -1;
                    if (activeEnemies.Count <= _moveDownWithLifeEnemies) MoveRow(g.ToList(), 0, -_moveDownStep);
                }
            }            
        }

        OnEndEnemies?.Invoke();
    }

    private void MoveRow(List<EnemyComponent> enemies,  float dir, float stepY)
    {
        enemies.ForEach(x=>x.transform.position += new Vector3(dir, stepY, 0));
    }
}
