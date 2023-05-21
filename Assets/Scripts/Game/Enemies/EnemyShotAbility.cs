using UnityEngine;
using Zenject;

public class EnemyShotAbility : ABaseShotAbility
{       
    public void Init(WorldBorders borders)
    {
        worldBorders = borders;        
    }

    public override bool CanShoot()
    {
        bool canShot = true;
        RaycastHit2D hit = Physics2D.Raycast(shotPoint.position, -shotPoint.up, transform.position.y - worldBorders.MinY);
        if (hit.collider != null && hit.collider.GetComponentInParent<EnemyComponent>() != null) canShot = false;
        return canShot;
    }

    public override void Shot()
    {
        var bullet = bulletFactory.Create(currentBulletData.BulletPrefab, transform.position);
        bullet.Init(currentBulletData.Speed, currentBulletData.Damage, worldBorders);
        bullet.Move(Vector2.down);

    }
}
