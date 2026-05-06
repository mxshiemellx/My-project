using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public int coinCount = 0;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected!");
        if(collision.gameObject.name.StartsWith("Coin"))
        {
            Destroy(collision.gameObject); // remove the coin
            coinCount++;
            Debug.Log($"Coin collected, coins:{coinCount}"); // increment and log the coin count
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
        }
    }
}