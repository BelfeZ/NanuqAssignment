using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    [Header("Parallax Configuration")]
    [SerializeField] private float speed;
    [SerializeField] private float parallaxEffect;
    [Space(8)]
    [Header("For testing")]
    [SerializeField] private bool isPausing;

    private float length, scroll;
    private Vector3 startpos;

    public void PauseBackground()
    {
        isPausing = true;
    }

    void Start()
    {
        startpos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        if (!isPausing)
        {
            scroll += speed * parallaxEffect * Time.deltaTime;
            float offset = Mathf.Repeat(scroll, length);
            transform.position = startpos + Vector3.left * offset;
        }
    }
}