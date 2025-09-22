using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [Header("Parallax Material")]
    [SerializeField] private GameObject camera;

    [Header("Parallax Configuration")]
    [SerializeField] private float parallaxEffect;

    private float length, startpos;

    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float dist = (camera.transform.position += Vector3.right * Time.deltaTime).x * parallaxEffect;
        float temp = camera.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length) startpos += length;
        else if (temp < startpos - length) startpos -= length;
    }
}