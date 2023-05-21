using System;

public interface ICounter<T>
{
    event Action OnChangeValue;
    T Value { get; }

    public void Add(T value);
}
