using System;
using UnityEngine;

public class HeathComponent : MonoBehaviour
{
    [SerializeField] private float _startHealth;

    public event Action onDie;
    public float CurrentHealth { get; private set; }

    private void Awake()
    {
        CurrentHealth = _startHealth;
    }

    public void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        CurrentHealth = Mathf.Clamp(CurrentHealth, 0, _startHealth);

        if(CurrentHealth <= 0)
            onDie?.Invoke();
    }
}
