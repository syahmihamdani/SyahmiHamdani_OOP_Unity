using UnityEngine;

public class EnemyTarget : Enemy
{
    [SerializeField] private float speed = 5f;
    private Transform player; // Reference to the player's transform

    private void Start()
    {
        // Find the player by name or tag
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        // Spawn the enemy randomly from the left or right side of the screen
        float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        float screenTop = Camera.main.orthographicSize;
        float spawnX = Random.Range(-screenHalfWidth, screenHalfWidth);
        transform.position = new Vector2(spawnX, screenTop + 1f); // Spawn slightly above the top of the screen
    }

    private void Update()
    {
        if (player == null) return;

        // Move towards the player's position
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the enemy collides with the player
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroy the enemy object upon collision with the player
        }
    }
}
