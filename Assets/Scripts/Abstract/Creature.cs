using System;
using UnityEngine;

public abstract class Creature : Entity, IDamageable, IRevealable
{
    [SerializeField] private float health = 100f;


    public float Health => health;

    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Debug.Log($"{gameObject.name}" + " died");
    }

    public override void Reveal()
    {
        Debug.Log($"{gameObject.name}" + "revealed");
    }
}
