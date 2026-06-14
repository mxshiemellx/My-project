using UnityEngine;

public class DiagonalCube : MonoBehaviour
{
    public float speed = 2f;
    public float range = 3f;

    public enum DiagonalAxis { XY, XZ, YZ }
    public DiagonalAxis axis = DiagonalAxis.XY; // choose in Inspector

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
        float offset = Mathf.Sin(Time.time * speed) * range;

        Vector3 newPosition = startPosition;

        switch (axis)
        {
            case DiagonalAxis.XY:
                newPosition.x = startPosition.x + offset;
                newPosition.y = startPosition.y + offset;
                break;
            case DiagonalAxis.XZ:
                newPosition.x = startPosition.x + offset;
                newPosition.z = startPosition.z + offset;
                break;
            case DiagonalAxis.YZ:
                newPosition.y = startPosition.y + offset;
                newPosition.z = startPosition.z + offset;
                break;
        }

        rb.MovePosition(newPosition);
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