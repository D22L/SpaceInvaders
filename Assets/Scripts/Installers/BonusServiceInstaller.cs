using UnityEngine;
using Zenject;

public class BonusServiceInstaller : MonoInstaller
{
    [SerializeField] private BulletBonusService _bonusService;
    public override void InstallBindings()
    {
        BindService();
    }

    private void BindService()
    {
        Container.Bind<BulletBonusService>().FromComponentInNewPrefab(_bonusService).AsSingle().NonLazy();
    }
}