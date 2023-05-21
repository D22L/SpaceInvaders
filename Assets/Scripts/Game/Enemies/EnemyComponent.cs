using System;
using UnityEngine;

public class EnemyComponent : MonoBehaviour
{
    [SerializeField] private HeathComponent _heathComponent;
    [SerializeField] private EnemyShotAbility _enemyShotAbility;
    public bool CanAttack => _enemyShotAbility.CanShoot();
    public bool isLife => _heathComponent.CurrentHealth > 0;
    
    private Action<Vector2> _counting;
    public void Init(WorldBorders worldBorders, Action<Vector2> counting)
    {        
        _enemyShotAbility.Init(worldBorders);
        _counting = counting;
    }

    private void OnEnable()
    {
        _heathComponent.onDie += OnDead;
    }

    private void OnDisable()
    {
        _heathComponent.onDie -= OnDead;
    }

    private void OnDead()
    {
        _counting?.Invoke(transform.position);
        gameObject.SetActive(false);
    }

    public void Attack()
    {
        _enemyShotAbility.Shot();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out HeathComponent healt))
        {
            healt.TakeDamage(healt.CurrentHealth);
        }
    }

}
