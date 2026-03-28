using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{
    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            MonoBehaviour[] allObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None);

            foreach (var obj in allObjects)
            {
                if (obj is IDamageable damageable)
                {
                    damageable.TakeDamage(5);
                    Debug.Log($"Damaged {obj.gameObject.name} via IDamageable");
                }
            }
        }
    }
}
