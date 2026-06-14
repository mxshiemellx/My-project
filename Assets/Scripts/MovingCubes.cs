using UnityEngine;

public class MovingCubes : MonoBehaviour
{
    public float speed = 2f;
    public float range = 3.5f; //control the range of movement
    
    public enum MoveAxis {X, Y, Z}
    public MoveAxis moveAxis = MoveAxis.Z; //can change this per cube in inspector
    
    private Rigidbody rb;
    private Vector3 startPosition;

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

        switch (moveAxis)
        {
            case MoveAxis.X:
                newPosition.x = startPosition.x + offset;
                break;
            case MoveAxis.Y:
                newPosition.y = startPosition.y + offset;
                break;
            case MoveAxis.Z:
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
            Debug.Log("Player attached to platform");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           collision.gameObject.transform.SetParent(null);
            Debug.Log("Player detached from platform");
        }
    }
}