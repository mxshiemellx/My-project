using UnityEngine;

public class movement : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0.1f, 0f, Space.World);
    }
}