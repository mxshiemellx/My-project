using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Transform respawnPoint; // drag your StartPosition here directly
    public float maxHealth = 100f;
    public float currentHealth;
    public Slider healthBar; 

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHealth = maxHealth;
        UpdateHealthBar();      
    }

    void Update()
    {
        if (transform.position.y < -20f)
        {
            Respawn();
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0f, maxHealth);
        UpdateHealthBar();

        Debug.Log("Player health: " + currentHealth);

        if (currentHealth <= 0f)
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

        currentHealth = maxHealth;
        UpdateHealthBar();

        // Show notification
        NotificationUI.instance.ShowMessage("✦ You died! Respawning...");
    }

    public void SetRespawnPoint(Transform newPoint)
    {
        respawnPoint = newPoint;
        Debug.Log("Respawn point updated to: " + newPoint.position);
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth;
        }
    }
}