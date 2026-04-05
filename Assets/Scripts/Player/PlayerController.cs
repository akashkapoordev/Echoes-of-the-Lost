using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour, IDamageable, IRevealable
{
    private InputAction moveAction;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private List<RuneFragment> runeFragments;
    private bool hasWon = false;
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
        healthPlayer.OnDamaged += OnDamagedReceived;
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

        if (!hasWon && runeFragments.Count == 0)
        {
            hasWon = true;
            Debug.Log("You win!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            healthPlayer.TakeDamage(10);

        }
    }

public void RemoveRuneFragment(RuneFragment runeFragment)
    {
        runeFragments.Remove(runeFragment);
    }

    public virtual void OnDamagedReceived(float amount)
    {
        Debug.Log($"Took {amount} damage! Health: {healthPlayer.currentHealth}");
    }

public void Die()
    {
        Debug.Log($"{gameObject.name} died");
        HandleDeath();
    }

    public bool IsDead() => healthPlayer.IsDead();

    public virtual void Reveal()
    {
        Debug.Log("Player Reveal");
    }

    private void OnDisable()
    {
        healthPlayer.OnDamaged -= OnDamagedReceived;
        healthPlayer.OnDied -= HandleDeath;
    }
}
