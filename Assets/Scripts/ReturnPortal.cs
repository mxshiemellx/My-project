using UnityEngine;

public class ReturnPortal : MonoBehaviour
{
    public Transform returnPosition; // drag your main island start position here
    private bool isTeleporting = false;
    private bool isLocked = true;

    public void LockPortal()
    {   isLocked = true;
        Debug.Log("Portal locked!");
    }

    public void UnlockPortal()
    {   isLocked = false;
        Debug.Log("Portal unlocked!");

        // Show notification
        NotificationUI.instance.ShowMessage("✦ Portal Unlocked! All coins collected!");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&& !isTeleporting)
        {
            if (isLocked)
            {
                // Show notification
                NotificationUI.instance.ShowMessage("✦ Portal Locked! Collect all coins first!");

                Debug.Log("Portal is locked! Collect all coins to unlock.");
                return;
            }

            isTeleporting = true;
            TeleportPlayer(other);
            Invoke("ResetPortal", 1f);
        }
    }

    void TeleportPlayer(Collider player)
    {
        if (returnPosition == null)
        {
            return;
        }

    player.transform.SetParent(null);

    // Reset velocity
    Rigidbody rb = player.GetComponent<Rigidbody>();
    if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        //Teleport
        player.transform.position = returnPosition.position;
        // Show notification
        NotificationUI.instance.ShowMessage("✦ Returned to Main Island!");
        Debug.Log("Player teleported to: " + returnPosition.position);

        //update respawn point
        PlayerHealth playerHealth =player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
            {
                playerHealth.SetRespawnPoint(returnPosition);
            }
    }

    void ResetPortal()
    {
        isTeleporting = false;
    }
}