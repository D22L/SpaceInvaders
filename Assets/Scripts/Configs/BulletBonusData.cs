using UnityEngine;

[CreateAssetMenu(fileName = "BulletBonusData", menuName = "Configs/BulletBonusData")]
public class BulletBonusData : ScriptableObject
{
    [field: SerializeField] public BulletData BulletData { get; private set; }
}
