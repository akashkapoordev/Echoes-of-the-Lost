using UnityEngine;

public abstract class Creature : Entity, IDamageable
{
    [SerializeField] protected CreatureConfig creatureConfig;
    protected Health health;


    public float Health => health != null ? health.currentHealth : 0f;

public virtual void OnDamagedReceived(float amount)
    {
        if (health != null)
        {
            health.TakeDamage(amount);
        }
    }

public virtual void Die()
    {
        Debug.Log($"{gameObject.name} died");
    }

public bool IsDead() => health != null && health.IsDead();


public override void Reveal()
    {
        IsRevealed = true;
        Debug.Log($"{gameObject.name} revealed");
    }

protected virtual void OnDisable()
    {
        if (health != null) { health.OnDied -= Die; }
    }



protected virtual void Awake()
    {
        health = GetComponent<Health>();
    }

protected virtual void OnEnable()
    {
        if (health != null) { health.OnDied += Die; }
    }

}
