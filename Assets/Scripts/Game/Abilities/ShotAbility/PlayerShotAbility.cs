using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class PlayerShotAbility : ABaseShotAbility
{
    [SerializeField] private float timeout;

    private IInputService _inputService;
    private Timer _timer;

    protected override void Awake()
    {
        base.Awake();
        _timer = new Timer(timeout);
    }

    [Inject]
    public void Construct(IInputService inputService, GameWorldSettings gameWorldSettings)
    {
        _inputService = inputService;
        worldBorders = gameWorldSettings.WorldBorders;

        _inputService.OnShotInput += OnShotInput;
    }

    private void OnShotInput()
    {
        Execute();
    }

    public void SetBullet(BulletData bulletData)
    {
        currentBulletData = bulletData;
    }

    public override bool CanShoot()
    {
        return !_timer.isActive;
    }

    public override void Shot()
    {
        var bullet = bulletFactory.Create(currentBulletData.BulletPrefab, transform.position);
        bullet.Init(currentBulletData.Speed, currentBulletData.Damage, worldBorders);
        bullet.Move(Vector2.up);        
        _timer.Start();
    }
}
