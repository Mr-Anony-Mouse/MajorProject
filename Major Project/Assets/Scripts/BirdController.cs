using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;
    private GameManager gameManager;
    private bool isAlive = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindFirstObjectByType<GameManager>();
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            if (rb.bodyType == RigidbodyType2D.Kinematic)
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                gameManager.StartGame();
            }

            if (isAlive)
            {
                rb.linearVelocity = Vector2.zero;
                rb.AddForce(Vector2.up * flapForce, ForceMode2D.Impulse);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (isAlive)
        {
            isAlive = false;
            gameManager.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ScoreZone"))
        {
            gameManager.IncreaseScore();
        }
    }
}