using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public int coinCount = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Coin detected!");

            Destroy(other.gameObject);
            coinCount++;

            Debug.Log("Coin collected, coins: " + coinCount);

            // Add to score UI
            ScoreManager.instance.AddScore(1);
            Debug.Log("Score updated: " + ScoreManager.instance.GetScore());
        }
    }
}