using UniRx;
using UnityEngine;

[System.Serializable]
public class BulletComponent : MonoBehaviour
{
    private float _speed;
    private float _damage;
    private WorldBorders _worldBordes;
    public void Init(float speed, float damage, WorldBorders worldBordes)
    {
        _speed = speed;
        _damage = damage;
        _worldBordes = worldBordes;
    }

    public void Move(Vector2 direction)
    {
        Observable.EveryUpdate() 
            .Subscribe(x => 
            {
                transform.position += (Vector3)direction * _speed * Time.deltaTime;
                if (transform.position.y < _worldBordes.MinY || transform.position.y > _worldBordes.MaxY) 
                {
                    Destroy(gameObject);
                }
            })
            .AddTo(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent(out HeathComponent heathComponent))
        {
            heathComponent.TakeDamage(_damage);
        }

        Destroy(gameObject);
    }    
}
