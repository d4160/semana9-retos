using UnityEngine;

public class PlayerAttack : AttackBase
{
    public float attackRate = 1f;

    private float _attackRateTimer = 0;

    void Update()
    {
        _attackRateTimer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && _attackRateTimer > attackRate)
        {
            Attack();
            _attackRateTimer = 0;
        }
    }
}
