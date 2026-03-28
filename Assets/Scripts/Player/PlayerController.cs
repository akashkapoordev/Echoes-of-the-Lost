using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour,IDamageable,IRevealable
{
    InputAction moveAction;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] List<RuneFragment> list;
    [SerializeField] private float health = 100;
    public float Health => health;

    private void Start()
    {
        gameoverPanel.SetActive(false);
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        transform.Translate(moveValue.x * moveSpeed * Time.deltaTime, 0, moveValue.y *moveSpeed * Time.deltaTime);

        if(list.Count == 0)
        {
            Debug.Log("You win");
            return;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if(!IsDead())
            {
                TakeDamage(10);
                
            }
            else
            {
                gameoverPanel.SetActive(true);
                this.enabled = false;
            }
            
        }
    }

    public void RemoveRuneFragment(RuneFragment runeFragment)
    {
        list.Remove(runeFragment);
    }

    public virtual void TakeDamage(float amount)
    {
        health -= amount;
        //Debug.Log($"{gameObject.name} took {amount} damage. Remaining health: {health}");
        if (health <= 0)
        {
            Die();
        }
    }

    public  void Die()
    {
        Debug.Log($"{gameObject.name}" + " died");
    }

    public bool IsDead() => health <= 0;

    public virtual void Reveal()
    {
        Debug.Log("Player Reveal");
    }
}    
