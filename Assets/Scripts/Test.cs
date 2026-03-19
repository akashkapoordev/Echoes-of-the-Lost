using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] Health health;



    private void Start()
    {
        health.TakeDamage(50);
        //Debug.Log( health.currentHealth);
    }
}
