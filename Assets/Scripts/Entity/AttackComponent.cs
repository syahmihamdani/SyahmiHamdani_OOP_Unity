using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class AttackComponent : MonoBehaviour
{
    [SerializeField] private Bullet bullet;
    [SerializeField] private int damage; 

    private void OnTriggerEnter2D(Collider2D other)
    {

        HitboxComponent hitbox = other.GetComponent<HitboxComponent>();
        InvincibilityComponent invincibility = other.GetComponent<InvincibilityComponent>();

        if (hitbox != null)
        {
            if (invincibility != null)
            {
                invincibility.TriggerInvincibility();
            }

            hitbox.Damage(damage);
        }
    }
}
