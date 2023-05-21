using UnityEngine;
using Zenject;
using UniRx;

public class BulletBonusView : MonoBehaviour
{
    [SerializeField] private float _speed = 2f;
    private WorldBorders _worldBorders;
    public BulletData BulletDataValue { get; private set; }    
    public void Init(WorldBorders worldBorders, BulletData bulletData)
    {
        _worldBorders = worldBorders;
        BulletDataValue = bulletData;
    }   
    public void Move()
    {
        Observable.EveryUpdate()
           .Subscribe(x =>
           {
               transform.position += (Vector3)Vector2.down * _speed * Time.deltaTime;
               if (transform.position.y < _worldBorders.MinY || transform.position.y > _worldBorders.MaxY)
               {
                   Destroy(gameObject);
               }
           })
           .AddTo(this);
    }

    public void Take()
    {
        Destroy(gameObject);
    }
}
