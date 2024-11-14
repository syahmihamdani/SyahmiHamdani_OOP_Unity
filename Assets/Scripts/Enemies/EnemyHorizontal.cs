using System.Collections;
using UnityEngine;

public class EnemyHorizontal : Enemy
{
    [SerializeField] private float speed = 5f;
    private Vector2 direction;

    private void Start()
    {
        // Spawn enemy randomly on either left or right side of the screen
        float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;

        if (Random.Range(0, 2) == 0)  // 0: spawn on left, 1: spawn on right
        {
            transform.position = new Vector2(-screenHalfWidth - 1f, Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize));
            direction = Vector2.right;  // Move right if spawned on left
        }
        else
        {
            transform.position = new Vector2(screenHalfWidth + 1f, Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize));
            direction = Vector2.left;  // Move left if spawned on right
        }
    }

    private void Update()
    {
        // Move the enemy
        transform.Translate(direction * speed * Time.deltaTime);

        // Check if the enemy is out of bounds and reverse direction if necessary
        float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        if (transform.position.x > screenHalfWidth + 1f || transform.position.x < -screenHalfWidth - 1f)
        {
            direction = -direction;
        }
    }
}
