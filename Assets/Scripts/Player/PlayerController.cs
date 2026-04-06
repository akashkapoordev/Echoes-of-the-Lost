using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour, IDamageable, IRevealable
{
    [Header("Input Action")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private InputActionReference jumpAaction;

    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject gameoverPanel;
    [SerializeField] private List<RuneFragment> runeFragments;
    [SerializeField] private CharacterController characterController;


    private bool isGrounded;
    private float jumpHeight = 1.5f;
    private float gravityValue = -20f;
    private Vector2 playerVelocity;
    private bool hasWon = false;
    private Health healthPlayer;
    public float Health => healthPlayer.currentHealth;

    private void Awake()
    {
        healthPlayer = GetComponent<Health>();
    }
    private void Start()
    {
        moveAction.action.Enable();
        jumpAaction.action.Enable();
        gameoverPanel.SetActive(false);
       
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
        isGrounded = characterController.isGrounded;

        //if(isGrounded)
        //{
        //    if(playerVelocity.y < -2f)
        //    {
        //        playerVelocity.y = 2f;
        //    }
        //}

        HandleMovement();

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

    private void HandleMovement()
    {
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = Vector3.ClampMagnitude(move, 1f);

        if(move != Vector3.zero)
        {
            transform.forward = move;
        }

        //jump 
        if(isGrounded & jumpAaction.action.WasPerformedThisFrame())
        {
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        //applygravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        //move
        Vector3 finalMove = move * moveSpeed + Vector3.up * playerVelocity.y;
        characterController.Move(finalMove * Time.deltaTime);
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAaction.action.Disable();
        healthPlayer.OnDamaged -= OnDamagedReceived;
        healthPlayer.OnDied -= HandleDeath;
    }
}
