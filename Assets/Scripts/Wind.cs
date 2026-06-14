using UnityEngine;

public class Wind : MonoBehaviour
{
    public Vector3 windDirection = new Vector3(1f, 0f, 0f); // pushes right by default
    public float windStrength = 10f;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(windDirection.normalized * windStrength, ForceMode.Force);
            }
        }
    }

    // Visual indicator in editor so you can see the wind zone
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0.5f, 0.8f, 1f, 0.3f);
        Gizmos.DrawCube(transform.position, transform.localScale);
        Gizmos.color = Color.cyan;
        Gizmos.DrawRay(transform.position, windDirection.normalized * 3f);
    }
}