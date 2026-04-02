using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour, IDamageable, IRevealable
{
    private InputAction moveAction;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private List<RuneFragment> list;
    private Health healthPlayer;
    public float Health => healthPlayer.currentHealth;

    private void Awake()
    {
        healthPlayer = GetComponent<Health>();
    }
    private void Start()
    {
        gameoverPanel.SetActive(false);
        moveAction = InputSystem.actions.FindAction("Move");
       
    }

    private void OnEnable()
    {
        healthPlayer.OnDamaged += TakeDamage;
        healthPlayer.OnDied += HandleDeath;
    }

    private void HandleDeath()
    {
        gameoverPanel.SetActive(true);
        this.enabled = false;
    }

    private void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        transform.Translate(moveValue.x * moveSpeed * Time.deltaTime, 0, moveValue.y * moveSpeed * Time.deltaTime);

        if (list.Count == 0)
        {
            Debug.Log("You win");
            return;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(10);

        }
    }

    public void RemoveRuneFragment(RuneFragment runeFragment)
    {
        list.Remove(runeFragment);
    }

    public virtual void TakeDamage(float amount)
    {
        healthPlayer.TakeDamage(amount);
    }

    public void Die()
    {
        Debug.Log($"{gameObject.name}" + " died");
    }

    public bool IsDead() => healthPlayer.IsDead();

    public virtual void Reveal()
    {
        Debug.Log("Player Reveal");
    }

    private void OnDisable()
    {
        healthPlayer.OnDamaged -= TakeDamage;
        healthPlayer.OnDied -= HandleDeath;
    }
}
