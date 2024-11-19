using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class HitboxComponent : MonoBehaviour
{
    [SerializeField] private HealthComponent health; 

    public void Damage(int damage)
    {
        InvincibilityComponent invincibility = GetComponent<InvincibilityComponent>();

        if (invincibility != null && invincibility.isInvincible)
        {
            return;
        }

        health.Subtract(damage);
    }
}
