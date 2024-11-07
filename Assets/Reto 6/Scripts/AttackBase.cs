using UnityEngine;

public abstract class AttackBase : MonoBehaviour
{
    public Vector2 attackDirection = Vector2.down;
    public float projectileSpeed = 10f;
    public Vector2Int minMaxDamageAmount = new Vector2Int(5, 10);

    [Header("References")]
    public Transform attackPoint;
    public Projectile projectilePrefab;

    public int DamageAmount => Random.Range(minMaxDamageAmount.x, minMaxDamageAmount.y + 1);

    public void Attack()
    {
        Attack(transform.right);
    }

    public void Attack(Vector3 direction)
    {
        Projectile projectile = Instantiate();
        projectile.transform.right = direction;
        projectile.Movement.SetVelocity(direction.normalized * projectileSpeed);
        projectile.DamageStat.SetDamage(DamageAmount);
    }

    protected virtual Projectile Instantiate()
    {
        return Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);
    }
}
