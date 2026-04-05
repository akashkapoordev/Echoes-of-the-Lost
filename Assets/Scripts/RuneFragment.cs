// RuneFragment - collectible item
using UnityEngine;

public class RuneFragment : MonoBehaviour
{
     
    [SerializeField] GameObject burstEffect;
private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController player = other.GetComponent<PlayerController>();
            ScoreManager score = other.GetComponent<ScoreManager>();

            if (player != null) player.RemoveRuneFragment(this);
            if (score != null) score.AddScore(10);

            BurstEffect();
            Destroy(gameObject);
        }
    }
    
    private void BurstEffect()
    {
       GameObject effect =  Instantiate(burstEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
    }
}
