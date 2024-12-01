using System.Collections;
using UnityEngine;

public class EnemyHorizontal : Enemy
{
    [SerializeField] private float speed = 5f;
    private Vector2 direction;

    private void Start()
    {
        float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;

        if (Random.Range(0, 2) == 0)  
        if (Random.Range(0, 2) == 0)  
        {
            transform.position = new Vector2(-screenHalfWidth - 1f, Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize));
            direction = Vector2.right; 
            direction = Vector2.right;  
        }
        else
        {
            transform.position = new Vector2(screenHalfWidth + 1f, Random.Range(-Camera.main.orthographicSize, Camera.main.orthographicSize));
            direction = Vector2.left;  
            direction = Vector2.left;  
        }
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        if (transform.position.x > screenHalfWidth + 1f || transform.position.x < -screenHalfWidth - 1f)
        {
            direction = -direction;
        }
    }
}