using UnityEngine;

public class SpinningObstacle : MonoBehaviour
{
    public float spinSpeed = 90f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    void FixedUpdate()
    {
        // Spin using Rigidbody so physics work correctly
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, spinSpeed * Time.fixedDeltaTime, 0f));
    }
}