using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : IStateMachine
{
    private IState _currentState;
    private IStateMachineHolder _holder;

    public IState PreviousState { get; private set; }

    public StateMachine (IStateMachineHolder holder)
    {                
        _holder = holder;
    }

    public void TrySwichState<T>() where T : IState
    {
        _currentState?.Exit();
        var newState = _holder.States.Find(x=> x is T);
        if (newState == null) return;
        
        if(_currentState!=null) PreviousState = _currentState;

        _currentState = newState;
        _currentState.Enter();
    }

    public void Update() => _currentState?.Update();
    public void FixedUpdate() => _currentState?.FixedUpdate();
}
