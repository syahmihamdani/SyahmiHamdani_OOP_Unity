using System.Collections;
using UnityEngine;

public class EnemyForward : Enemy
{
    [SerializeField] private float speed = 5f;
    private Vector2 direction = Vector2.down; // Start moving downwards

    private void Start()
    {
        // Spawn enemy randomly along the top of the screen
        float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        float screenTop = Camera.main.orthographicSize;
        transform.position = new Vector2(Random.Range(-screenHalfWidth, screenHalfWidth), screenTop + 1f);  // Slightly above the screen
    }

    private void Update()
    {
        // Move the enemy
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the enemy is out of bounds vertically and reverse direction if necessary
        float screenTop = Camera.main.orthographicSize;
        float screenBottom = -screenTop;

        if (transform.position.y < screenBottom - 1f || transform.position.y > screenTop + 1f)
        {
            direction = -direction; // Reverse the direction
        }
    }
}
