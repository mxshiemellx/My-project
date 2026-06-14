using UnityEngine;

public class SpinningObstacle : MonoBehaviour
{
    public float spinSpeed = 45f; // degrees per second

    void Update()
    {
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform);
            Debug.Log("Player is attached to spinning obstacle");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null);
            Debug.Log("Player is detached from spinning obstacle");
        }
    }
}