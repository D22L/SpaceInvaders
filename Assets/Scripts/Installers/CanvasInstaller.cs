using UnityEngine;
using Zenject;

public class CanvasInstaller : MonoInstaller
{
    [SerializeField] private UIWindowController _uiWindowController;
    public override void InstallBindings()
    {
        Container.Bind<UIWindowController>().FromComponentInNewPrefab(_uiWindowController).AsSingle().NonLazy();
    }
}