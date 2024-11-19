using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    private Rigidbody2D rb;

    private Vector2 direction = Vector2.up;

    private IObjectPool<Bullet> objectPool;
    public IObjectPool<Bullet> ObjectPool { set => objectPool = value; }

    public void Deactivate()
    {
        StartCoroutine(DeactivateRoutine(3f));
    }

    IEnumerator DeactivateRoutine(float delay)
    {
        yield return new WaitForSeconds(delay);

        rb.velocity = new Vector3(0f, 0f, 0f);
        rb.angularVelocity = 0f;

        objectPool.Release(this);
    }

    public void InitializeBullet(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = direction * speed;
    }
}
