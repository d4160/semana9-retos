using UnityEngine;

[RequireComponent(typeof(BossMovement), typeof(BossAttack))]
[RequireComponent(typeof(BossMovement2), typeof(BossAttack2))]
[RequireComponent(typeof(HpStat))]
public class Boss : MonoBehaviour
{
    private BossMovement _movement1;
    private BossMovement2 _movement2;
    private BossAttack _attack1;
    private BossAttack2 _attack2;
    private HpStat _hpStat;

    void Awake()
    {
        _movement1 = GetComponent<BossMovement>();
        _movement2 = GetComponent<BossMovement2>();
        _attack1 = GetComponent<BossAttack>();
        _attack2 = GetComponent<BossAttack2>();
        _hpStat = GetComponent<HpStat>();
    }

    void Update()
    {
        if (_hpStat.CurrentPercentage <= 0.31f)
        {
            _movement1.enabled = false;
            _movement2.enabled = true;
            _attack1.enabled = false;
            _attack2.enabled = true;
        }
        else
        {
            _movement1.enabled = true;
            _movement2.enabled = false;
            _attack1.enabled = true;
            _attack2.enabled = false;
        }
    }
}
