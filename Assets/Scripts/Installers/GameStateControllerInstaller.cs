using UnityEngine;
using Zenject;

public class GameStateControllerInstaller : MonoInstaller
{
    [SerializeField] private GameStateController _gameStateController;
    public override void InstallBindings()
    {
        BindGameStateController();
    }

    private void BindGameStateController()
    {
        Container.Bind<GameStateController>().FromComponentInNewPrefab(_gameStateController).AsSingle().NonLazy();
    }
}