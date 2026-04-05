using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
     

    public event Action<float> OnDamaged;
    public event Action<float> OnHealed;
    public event Action OnDied;


    private bool isDead = false;
    public float currentHealth { get; private set; }

private void Start()
    {
        currentHealth = maxHealth;
    }

public void SetMaxHealth(float value)
    {
        maxHealth = value;
        currentHealth = maxHealth;
    }


public void TakeDamage(float amount)
    {
        if (isDead) return;
        currentHealth = Mathf.Max(0, currentHealth - amount);
        OnDamaged?.Invoke(amount);
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            OnDied?.Invoke();
        }
    }

public void Heal(float amount)
    {
        if (isDead) return;
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
        OnHealed?.Invoke(amount);
    }


    public bool IsDead() => currentHealth <= 0;
 
}
