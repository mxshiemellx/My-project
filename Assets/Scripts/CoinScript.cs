using UnityEngine;

public class CoinScript : MonoBehaviour, IInteractable
{
    public int score = 1;
    public AudioSource audioSource;
    public IslandCoinManager islandCoinManager;

    public int Interact()
    {
        if (audioSource != null)
        {
            //Play the coin collect sound
            audioSource.Play();
        }

        //Hide the coin
        var renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
            Debug.Log("Coin collected! Score: " + score);
        }

        if (islandCoinManager != null)
        {
            islandCoinManager.CoinCollected();
        }
        
        //Destroy the coin after 1 second
        Destroy(gameObject, 1);
        return score;
    }
}
    