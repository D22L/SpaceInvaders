using System;

public interface IInputService : IService, IInitialized
{
    float HorizontalInput { get; }
    float VerticalInput { get; }
    
    event Action OnShotInput;
}
