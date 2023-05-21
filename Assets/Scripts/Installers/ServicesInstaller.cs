using UnityEngine;
using Zenject;

public class ServicesInstaller : MonoInstaller
{
    [SerializeField] private InputService _inputService;    

    public override void InstallBindings()
    {   
        BindImputService();
        BindEnemyCounter();
    }
    private void BindEnemyCounter()
    {
        EnemyCounter enemyCounter = new EnemyCounter();
        Container.Bind<EnemyCounter>().FromInstance(enemyCounter).AsSingle().NonLazy();
    }
    private void BindImputService()
    {
        Container.Bind<IInputService>().To<InputService>().FromComponentInNewPrefab(_inputService).AsSingle().NonLazy();
    }

}