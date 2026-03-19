using TMPro;
using UnityEngine;

public class RuneFragment : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject burstEffect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<ScoreManager>().AddScore(10);
            BurstEffect();
            Destroy(this.gameObject);

          
        }
    }

    private void BurstEffect()
    {
       GameObject effect =  Instantiate(burstEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1f);
    }
}
