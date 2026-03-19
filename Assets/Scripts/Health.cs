using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHealth;

    public float currentHealth { get; private set; }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if(!IsDead())
            {
            currentHealth = Mathf.Max(0, currentHealth - amount);
            Debug.Log(currentHealth);
        }
      


    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(maxHealth, currentHealth + amount);
    }

    public bool IsDead()
    {
        if (currentHealth <= 0) return true;

        return false;
    }

}
