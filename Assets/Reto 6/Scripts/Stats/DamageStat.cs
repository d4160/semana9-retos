using UnityEngine;

public class DamageStat : MonoBehaviour
{
    public int damageAmount;

    public void SetDamage(int damage)
    {
        damageAmount = damage;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.rigidbody.TryGetComponent<HpStat>(out var otherHp))
        {
            otherHp.TakeDamage(damageAmount);
        }

        if (gameObject.TryGetComponent<Projectile>(out var projectile))
        {
            projectile.InstantiateImpact(other.contacts[0].point);
            Destroy(gameObject);
        }
    }
}
