using UnityEngine;

[CreateAssetMenu(fileName = "GameWorldSettings", menuName = "Configs/GameWorldSettings")]
public class GameWorldSettings : ScriptableObject
{
    [field: SerializeField] public WorldBorders WorldBorders { get; private set; }
}
