using UnityEngine;

public class BulletFactory : IFactory<BulletComponent>
{
    public BulletComponent Create(BulletComponent pfb, Vector3 position)
    {
        return MonoBehaviour.Instantiate(pfb, position, Quaternion.identity);
    }
}
