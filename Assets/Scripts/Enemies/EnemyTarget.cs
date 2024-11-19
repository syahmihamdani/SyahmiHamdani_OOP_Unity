using UnityEngine;

public class EnemyTarget : Enemy
{
    [SerializeField] private float speed = 5f;
    private Transform player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
        float screenHalfWidth = Camera.main.aspect * Camera.main.orthographicSize;
        float screenTop = Camera.main.orthographicSize;
        float spawnX = Random.Range(-screenHalfWidth, screenHalfWidth);
        transform.position = new Vector2(spawnX, screenTop + 1f);
    }

    private void Update()
    {
        if (player == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Destroy(gameObject); 
        }
    }
}
    