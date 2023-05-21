using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameWorldSettingsInstaller", menuName = "Installers/GameWorldSettingsInstaller")]
public class GameWorldSettingsInstaller : ScriptableObjectInstaller<GameWorldSettingsInstaller>
{
    [SerializeField] private GameWorldSettings _gameWorldSettings;
    public override void InstallBindings()
    {
        Container.Bind<GameWorldSettings>().FromInstance(_gameWorldSettings).AsSingle();
    }
}