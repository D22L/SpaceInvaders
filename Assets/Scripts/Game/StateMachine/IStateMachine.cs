using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStateMachine
{
    IState PreviousState { get; }
    public void TrySwichState<T>() where T :IState;
}
