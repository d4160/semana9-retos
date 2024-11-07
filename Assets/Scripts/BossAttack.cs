using UnityEngine;

public class BossAttack : AttackBase
{
    public Vector2 minMaxAttackRate = new Vector2(0.5f, 3);

    public float AttackRate => Random.Range(minMaxAttackRate.x, minMaxAttackRate.y);

    private float _rateTimer;
    private float _currentAttackRate;

    void Start()
    {
        CalculateNewAttackRate();
    }

    void Update()
    {
        _rateTimer += Time.deltaTime;

        if (_rateTimer > _currentAttackRate)
        {
            Attack();
            CalculateNewAttackRate();
            _rateTimer = 0;
        }
    }

    private void CalculateNewAttackRate()
    {
        _currentAttackRate = AttackRate;
    }
}
