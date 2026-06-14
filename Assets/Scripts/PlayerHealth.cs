using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Transform respawnPoint; // drag your StartPosition here directly
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (transform.position.y < -20f)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        // Detach from platform
        transform.SetParent(null);

        // Kill all velocity
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        // Teleport instantly
        transform.position = respawnPoint.position;

        // Show notification
        NotificationUI.instance.ShowMessage("✦ You died! Respawning...");
    }

    public void SetRespawnPoint(Transform newPoint)
    {
        respawnPoint = newPoint;
        Debug.Log("Respawn point updated to: " + newPoint.position);
    }
}