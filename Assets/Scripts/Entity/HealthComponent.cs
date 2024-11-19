using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public float maxHealth = 100f;
    private float health;

    public float Health => health;

    public void Subtract(float amount)
    {
        health -= amount;
        Debug.Log($"{gameObject.name} took {amount} damage!");


        if (health <= 0)
        {
            Die();
        }
    }

    void Start()
    {
        health = maxHealth;
    }

    private void Die()
    {
        Debug.Log("Object destroyed because health reached 0.");
        Destroy(gameObject);  
    }
}
