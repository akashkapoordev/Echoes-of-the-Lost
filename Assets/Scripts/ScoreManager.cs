using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    private int score;


    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score : " + score.ToString();
    }
}
