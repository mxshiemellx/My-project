using UnityEngine;
using TMPro;

public class WinCondition : MonoBehaviour
{
    public int coinsToWin = 10;
    public GameObject winScreen;

    void Update()
    {
        if (ScoreManager.instance.GetScore() >= coinsToWin)
        {
            Win();
        }
    }

    void Win()
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f; // pause the game
        Debug.Log("You win!");
    }
}