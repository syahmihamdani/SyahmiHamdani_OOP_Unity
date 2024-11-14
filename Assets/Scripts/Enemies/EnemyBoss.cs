using UnityEngine;

public class EnemyBoss : Enemy
{
    [Header("Enemy Boss Stats")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float shootIntervalInSeconds = 2f;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private Bullet bulletPrefab;

    private float shootTimer;

    private Transform player; // Reference to the player's transform
    private bool isMovingLeft = true; // Direction flag for horizontal movement

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        if (player == null)
        {
            Debug.LogError("Player not found! Ensure the player is tagged correctly.");
            return;
        }

        // Initial spawn position, can be set to spawn on either left or right of the screen
        float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        transform.position = new Vector2(Random.Range(-screenHalfWidth, screenHalfWidth), Camera.main.orthographicSize + 1f);
    }

    private void Update()
    {
        if (player == null) return;

        // Horizontal movement from left to right or right to left
        MoveHorizontally();

        // Shoot bullets at regular intervals
        ShootBullet();
    }

    private void MoveHorizontally()
    {
        // Move the enemy boss left or right depending on the flag
        float direction = isMovingLeft ? -1 : 1;
        transform.Translate(Vector2.right * direction * moveSpeed * Time.deltaTime);

        // Check if the enemy has crossed the screen, and reverse direction
        if (transform.position.x <= -Camera.main.aspect * Camera.main.orthographicSize || 
            transform.position.x >= Camera.main.aspect * Camera.main.orthographicSize)
        {
            isMovingLeft = !isMovingLeft; // Reverse direction
        }
    }

    private void ShootBullet()
    {
        // Timer for shooting bullets at intervals
        if (Time.time >= shootTimer)
        {
            shootTimer = Time.time + shootIntervalInSeconds;

            // Instantiate and shoot a bullet
            Bullet newBullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
            newBullet.InitializeBullet(Vector2.down); // Shoot downwards (or towards player, if needed)
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // If the boss collides with the player, destroy the boss
            Destroy(gameObject);
        }
    }
}
