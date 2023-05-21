using System;
using UnityEngine;

public class InputService : MonoBehaviour, IInputService
{
    public float HorizontalInput { get; private set; }
    public float VerticalInput { get; private set; }

    public bool IsInitialized { get; private set; }

    public event Action OnShotInput;    
    public void Initialize()
    {
        IsInitialized = true;
    }

    private void Update()
    {
        if (!IsInitialized) return;
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.Space))
        {
            OnShotInput?.Invoke();
        }
    }

}
