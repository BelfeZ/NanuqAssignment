using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Configuration")]
    [SerializeField] private float playerGravity;
    [SerializeField] private float playerFlyStrength;

    [Header("Player Status (For pausing player)")]
    [SerializeField] private bool isPlaying;
    [SerializeField] private Animator playerAnimator;

    private Vector3 direction;

    void Update()
    { 
        if (isPlaying && Input.GetMouseButtonDown(0))
        {
            direction = Vector3.up * playerFlyStrength;
            SoundManager.instance.PlayRandomJumpVfx();
        }

        if (isPlaying)
        {
            direction.y += playerGravity * Time.deltaTime;
            transform.position += direction * Time.deltaTime;
        }
    }

    public void ChangePlayerState()
    {
        if(Time.timeScale == 0) isPlaying = false;

        else if(Time.timeScale == 1) isPlaying = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle") 
        {
            isPlaying = false;
            SoundManager.instance.PlayVfx(1);
            playerAnimator.SetTrigger("dead");
            FindAnyObjectByType<GameManager>().StartCoroutine(FindAnyObjectByType<GameManager>().GameOver());
        }

        if (collision.gameObject.tag == "Score")
        {
            FindAnyObjectByType<GameManager>().IncreaseScore();
        }
    }
}