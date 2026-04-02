using System;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] TextMeshProUGUI health;

    public event Action<float> OnDamaged;
    public event Action<float> OnHealed;
    public event Action OnDied;


    public float currentHealth { get; private set; }

    private void Start()
    {
        currentHealth = maxHealth;
        health.text = "Health : " + currentHealth.ToString();
    }

    public void TakeDamage(float amount)
    {
        Debug.Log(currentHealth);
        currentHealth = Mathf.Max(0, currentHealth - amount);
        health.text = "Health : " + currentHealth.ToString();
        OnDamaged?.Invoke(amount);
            
        if(currentHealth <= 0)
        {
            OnDied?.Invoke();
        }
      


    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
    }


    public bool IsDead() => currentHealth <= 0;
 
}
