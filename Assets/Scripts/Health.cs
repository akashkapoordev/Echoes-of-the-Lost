using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;
    [SerializeField] TextMeshProUGUI health;

    public float currentHealth { get; private set; }

    private void Start()
    {
        currentHealth = maxHealth;
        health.text = "Health : " + currentHealth.ToString();
    }

    public void TakeDamage(float amount)
    {
        if(!IsDead())
            {
            currentHealth = Mathf.Max(0, currentHealth - amount);
            health.text = "Health : " + currentHealth.ToString();
        }
      


    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
    }

    public bool IsDead()
    {
        if (currentHealth < 0) return true;

        return false;
    }

}
