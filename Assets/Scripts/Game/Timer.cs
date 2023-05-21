using System;
using UniRx;
using UnityEngine;
public class Timer
{
    private float _time;
    private IDisposable _update;
    public event Action OnEnd;
    public bool isActive { get; private set; }
    public Timer (float time)
    {
        _time = time;
    }

    public void Stop()
    {
        isActive = false;
        _update.Dispose();
    }

    public void Start()
    {
        isActive = true;
        _update = Observable.Timer(System.TimeSpan.FromSeconds(_time))
        .Subscribe(_ => {
            isActive = false;
            OnEnd?.Invoke();
        });
    }
}
