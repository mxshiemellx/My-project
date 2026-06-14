using UnityEngine;

public class KillBlock: MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.Respawn();
                NotificationUI.instance.ShowMessage("✦ You died! Respawning...");
            }
        }
    }
}

