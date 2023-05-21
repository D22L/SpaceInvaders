using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBonusFactory : IFactory<BulletBonusView>
{
    public BulletBonusView Create(BulletBonusView pfb, Vector3 position)
    {
        return MonoBehaviour.Instantiate(pfb,position, Quaternion.identity);
    }
}
