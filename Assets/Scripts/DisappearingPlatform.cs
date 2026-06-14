using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{
    public float visibleTime = 4f;      // how long it stays solid
    public float invisibleTime = 2f;    // how long it stays gone
    public bool startVisible = true;    // whether it starts visible or hidden

    private MeshRenderer meshRenderer;
    private Collider platformCollider;

    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        platformCollider = GetComponent<Collider>();

        if (startVisible)
            // Change this in Start():
            Invoke("Disappear", visibleTime + Random.Range(0f, 4f)); // each platform disappears at slightly different times
        else
            Disappear(); // start already invisible
    }

    void Disappear()
    {
        meshRenderer.enabled = false;   // hide the platform
        platformCollider.enabled = false; // disable collision

        // Detach player if they're standing on it
        foreach (Transform child in transform)
        {
            if (child.CompareTag("Player"))
            {
                child.SetParent(null);
            }
        }

        Invoke("Reappear", invisibleTime);
    }

    void Reappear()
    {
        meshRenderer.enabled = true;    // show the platform
        platformCollider.enabled = true; // re-enable collision
        Invoke("Disappear", visibleTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
        }
    }
}