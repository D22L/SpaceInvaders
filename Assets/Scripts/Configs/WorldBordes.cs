using UnityEngine;

[System.Serializable]
public struct WorldBorders
{
    [field: SerializeField] public float MinX { get; private set; }
    [field: SerializeField] public float MaxX { get; private set; }
    [field: SerializeField] public float MinY { get; private set; }
    [field: SerializeField] public float MaxY { get; private set; }
}
