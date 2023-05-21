using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletBonusDatabase", menuName = "Configs/BulletBonusDatabase")]
public class BulletBonusDatabase : ScriptableObject
{
    [field: SerializeField] public BulletBonusView Pfb { get; private set; }
    [field:Range(0,100)]
    [field: SerializeField] public int DropChance { get; private set; } = 20;

    [SerializeField] private List<BulletBonusData> _bulletBonusDatas = new List<BulletBonusData>();

    public BulletBonusData GetRandomBonus()
    {
        var r = Random.Range(0, _bulletBonusDatas.Count);
        return _bulletBonusDatas[r];
    }
}
