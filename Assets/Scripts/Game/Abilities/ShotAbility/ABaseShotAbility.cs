using System;
using UnityEngine;

public abstract class ABaseShotAbility : MonoBehaviour, IAbility
{
    [SerializeField] protected BulletData defaultBulletData;
    [SerializeField] protected Transform shotPoint;
    
    protected WorldBorders worldBorders;
    protected BulletFactory bulletFactory;
    protected BulletData currentBulletData;

    protected virtual void Awake()
    {       
        currentBulletData = defaultBulletData;
        bulletFactory = new BulletFactory();
    }

    public virtual void Execute()
    {
        if (CanShoot())
        {
            Shot();            
        }
    }
    public abstract bool CanShoot();
    public abstract void Shot();

}
