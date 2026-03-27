using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    [SerializeField] float moveSpeed;
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] List<RuneFragment> list;

    private Health health;

    private void Start()
    {
        gameoverPanel.SetActive(false);
        moveAction = InputSystem.actions.FindAction("Move");
        health = GetComponent<Health>();
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
            if(!health.IsDead())
            {
                health.TakeDamage(10);
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
}    
