using UnityEngine;

public class BGUP : MonoBehaviour
{
    private float startPos, length;
    public GameObject cam;
    public float parallaxEffect; // The speed at which the background should move relative to the camera

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    void FixedUpdate()
    {
        // Calculate distance background move based on cam movement
        float distance = cam.transform.position.y * parallaxEffect; // = move with cam || 1 = won't move || 0.5 = half float movement cam.transform.position.x (1 parallaxEffect);
        float movement = cam.transform.position.y * (1 - parallaxEffect);
        transform.position = new Vector3(transform.position.y, startPos + distance, transform.position.z);
        // if background has reached the end of its length adjust its position for infinite scrolling if (movement > startPos + length)
        if (movement > startPos + length)
        {
            startPos += length;
        }
        else if (movement < startPos - length)
        {
            startPos -= length;
        }
    }
}