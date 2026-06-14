using UnityEngine;

public class IslandCoinManager : MonoBehaviour
{
    public ReturnPortal portal;        // drag your portal here
    public int totalCoins;             // set this to how many coins are on the island

    private int collectedCoins = 0;

    void Start()
    {
        // Make sure portal starts locked
        portal.LockPortal();

        // Auto count coins in the scene if you didnt set it manually
        if (totalCoins == 0)
        {
            totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
            Debug.Log("Total coins on island: " + totalCoins);
        }
    }

    public void CoinCollected()
    {
        collectedCoins++;
        Debug.Log("Coins collected: " + collectedCoins + "/" + totalCoins);

        if (collectedCoins >= totalCoins)
        {
            portal.UnlockPortal();
            Debug.Log("All coins collected! Portal unlocked!");
        }
    }
}