using UnityEngine;
using Zenject;

public class BulletBonusService: MonoBehaviour
{
    [SerializeField] private BulletBonusDatabase _bonusDatabase;

    private BulletBonusFactory _bulletFactory;
    private WorldBorders _worldBorders;
    private SwarmOfEnemies _swarmOfEnemies;

    [Inject]
    private void Construct(SwarmOfEnemies swarmOfEnemies, GameWorldSettings worldSettings)
    {
        _swarmOfEnemies = swarmOfEnemies;
        _worldBorders = worldSettings.WorldBorders;
    }

    private void Awake()
    {
        _bulletFactory = new BulletBonusFactory();
    }

    private void OnEnable()
    {
        _swarmOfEnemies.OnEnemyDead += TryDropBonus;
    }

    private void TryDropBonus(Vector2 obj)
    {
        var r = Random.Range(0, 100);
        if (r >= _bonusDatabase.DropChance) return;

       var bonusView = _bulletFactory.Create(_bonusDatabase.Pfb, obj);
       var bulletData = _bonusDatabase.GetRandomBonus();
       bonusView.Init(_worldBorders, bulletData.BulletData);
       bonusView.Move();
    }


    private void OnDisable()
    {
        _swarmOfEnemies.OnEnemyDead -= TryDropBonus;
    }

}
