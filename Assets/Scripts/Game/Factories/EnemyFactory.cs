using UnityEngine;
using Zenject;

public class EnemyFactory : IFactory<EnemyComponent>
{
    public EnemyComponent Create(EnemyComponent pfb, Vector3 position)
    {
        return MonoBehaviour.Instantiate(pfb, position, Quaternion.identity);
    }
}
