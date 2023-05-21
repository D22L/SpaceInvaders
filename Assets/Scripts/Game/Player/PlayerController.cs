using System;
using UnityEngine;
using Zenject;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerMoveComponent _moveComponent;
    [SerializeField] private HeathComponent _heathComponent;
    [SerializeField] private PlayerShotAbility _shotAbilitye;

    public event Action OnDead;

    private void OnEnable()
    {
        _heathComponent.onDie += _heathComponent_onDie;
    }

    private void _heathComponent_onDie()
    {
        gameObject.SetActive(false);
        OnDead?.Invoke();
    }

    private void OnDisable()
    {
        _heathComponent.onDie -= _heathComponent_onDie;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out BulletBonusView bonusView))
        {
            _shotAbilitye.SetBullet(bonusView.BulletDataValue);
            bonusView.Take();


        }
    }
}
