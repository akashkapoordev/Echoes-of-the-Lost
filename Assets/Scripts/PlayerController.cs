using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    InputAction moveAction;
    [SerializeField] float moveSpeed;

    private void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        transform.Translate(moveValue.x * moveSpeed * Time.deltaTime, 0, moveValue.y *moveSpeed * Time.deltaTime);
    }

}    
