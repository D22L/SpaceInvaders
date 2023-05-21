using UnityEngine;

[CreateAssetMenu(fileName = "BulletData", menuName = "Configs/BulletData")]
public class BulletData : ScriptableObject
{    
    [field: SerializeField] public float Speed { get; private set; }
    [field: SerializeField] public float Damage { get; private set; }
    [field: SerializeField] public BulletComponent BulletPrefab { get; private set;}
}
