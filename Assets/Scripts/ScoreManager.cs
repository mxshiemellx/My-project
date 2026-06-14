using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    private int totalScore = 0;

    void Awake()
    {
        instance = this;
    }

    public void AddScore(int amount)
    {
        totalScore += amount;
        scoreText.text = "Coins: " + totalScore;
    }

    public int GetScore()
    {
        return totalScore;
    }
}