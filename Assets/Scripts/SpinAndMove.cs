using UnityEngine;

public class SpinAndMove : MonoBehaviour
{
    public float spinSpeed = 90f;   // degrees per second
    public float moveSpeed = 2f;    // how fast it moves left and right
    public float moveRange = 3f;    // how far it moves left and right

    public enum MoveAxis { X, Z }
    public MoveAxis axis = MoveAxis.X; // pick which axis to move on

    private Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        startPosition = transform.position;
    }

    void FixedUpdate()
    {
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveRange;

        // Move left and right
        Vector3 newPosition = startPosition;
        if (axis == MoveAxis.X)
            newPosition.x = startPosition.x + offset;
        else
            newPosition.z = startPosition.z + offset;

        rb.MovePosition(newPosition);

        // Spin at the same time
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, spinSpeed * Time.fixedDeltaTime, 0f));
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