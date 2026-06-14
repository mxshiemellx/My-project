using UnityEngine;

public class DiagonalCube : MonoBehaviour
{
    public float speed = 2f;
    public float range = 3f;

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

        // moves diagonally by offsetting both Y and X at the same time
        Vector3 newPosition = startPosition + new Vector3(offset, offset, 0f);
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