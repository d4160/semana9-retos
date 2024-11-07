using UnityEngine;

public class BossAttack2 : AttackBase
{
    public Vector2 minMaxAttackRate = new Vector2(0.5f, 3);
    public float lookAtSmoothness = 14;
    public float lookAtDelay = 0.07f;

    [Header("References")]
    public Transform target;

    public float AttackRate => Random.Range(minMaxAttackRate.x, minMaxAttackRate.y);

    private float _rateTimer;
    private float _currentAttackRate;
    private float _lookAtDelayTimer;

    public Vector3 DirectionToTarget => target.position - transform.position;

    void Start()
    {
        CalculateNewAttackRate();
    }

    void Update()
    {
        _rateTimer += Time.deltaTime;

        if (_rateTimer > _currentAttackRate)
        {
            bool rotated = LookAtTarget();
            if (!rotated) return;

            Attack(DirectionToTarget);
            CalculateNewAttackRate();
            _rateTimer = 0;
        }
        else
        {
            _lookAtDelayTimer = 0;
        }
    }

    private bool LookAtTarget()
    {
        transform.right = Vector3.Lerp(transform.right, DirectionToTarget, Time.deltaTime * lookAtSmoothness);

        _lookAtDelayTimer += Time.deltaTime;
        if (_lookAtDelayTimer > lookAtDelay)
        {
            return true;
        }

        return false;
    }

    private void CalculateNewAttackRate()
    {
        _currentAttackRate = AttackRate;
    }
}
