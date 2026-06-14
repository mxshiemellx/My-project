using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private bool isActivated = false;
    public GameObject activeEffect; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true;
            
            //Update the player's respawn point directly
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.SetRespawnPoint(transform);
            }

             // Show notification
            NotificationUI.instance.ShowMessage("✦ Checkpoint Activated!");
            
            //Show active effect if assigned
            if (activeEffect != null)
                activeEffect.SetActive(true);

            Debug.Log("Checkpoint activated!");
        }
    }
}
