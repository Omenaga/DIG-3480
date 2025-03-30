using UnityEngine;

public class ZigZagMovement : MonoBehaviour
{
    public float speed = 1f;
    public float frequency = 4f;  // Zigzag Speed
    public float magnitude = 1f;  // Zigzag Width

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        // Move downwards
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Zigzag movement
        transform.position = new Vector3(startPosition.x + Mathf.Sin(Time.time * frequency) * magnitude, transform.position.y, transform.position.z);
    }
}
