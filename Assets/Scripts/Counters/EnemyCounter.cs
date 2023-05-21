using System;
using UnityEngine;

public class EnemyCounter : ICounter<int>
{
    public int Value { get; private set; }

    public event Action OnChangeValue;

    public void Add(int value)
    {
        Value += value;
        OnChangeValue?.Invoke();
    }
}
