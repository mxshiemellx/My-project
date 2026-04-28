using UnityEngine;

public class MyFirstScript1 : MonoBehaviour
{
    float move = 0.6f;
    float speed = 0.01f;

    // Update is called once per frame
    void Update()
    {
        // Rotate by 0.1f every frame on the Y axis of the world
        transform.Rotate(0f, 0.1f, 0f, Space.World);

        if (transform.position.x > 1f) move = -0.1f;
        if (transform.position.x < -1f) move = 0.1f;

        transform.position = new Vector3(
            transform.position.x + move,
            transform.position.y,
            transform.position.z

        );
    }
}
