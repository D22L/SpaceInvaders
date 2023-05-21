using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [Header("Player")]
    [SerializeField] private PlayerController _playerControllerPfb;
    [SerializeField] private Transform _playerStartPoint;

    [Header("Enemies")]
    [SerializeField] private SwarmOfEnemies _swarmOfEnemiesPfb;
    [SerializeField] private Transform _swarmOfEnemiesStartPoint;

    public override void InstallBindings()
    {
        BindPlayer();
        BindSwarmOfEnemies();
    }
    private void BindSwarmOfEnemies()
    {
        SwarmOfEnemies swarmOfEnemies = Container
            .InstantiatePrefabForComponent<SwarmOfEnemies>(_swarmOfEnemiesPfb, _swarmOfEnemiesStartPoint.position, Quaternion.identity, null);
       
        Container.Bind<SwarmOfEnemies>().FromInstance(swarmOfEnemies).AsSingle().NonLazy();
    }
    private void BindPlayer() 
    {
        PlayerController playerController = Container
            .InstantiatePrefabForComponent<PlayerController>(_playerControllerPfb, _playerStartPoint.position, Quaternion.identity, null);
        
        Container.Bind<PlayerController>().FromInstance(playerController).AsSingle().NonLazy();
    }
}