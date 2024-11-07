using UnityEngine;

[RequireComponent(typeof(ProjectileMovement), typeof(DamageStat))]
public class Projectile : MonoBehaviour
{
    [Header("References")]
    public GameObject muzzlePrefab;
    public GameObject impactPrefab;

    private ProjectileMovement _movement;
    private DamageStat _damageStat;

    public ProjectileMovement Movement => _movement;
    public DamageStat DamageStat => _damageStat;

    void Awake()
    {
        _movement = GetComponent<ProjectileMovement>();
        _damageStat = GetComponent<DamageStat>();
    }

    void Start()
    {
        if (muzzlePrefab)
        {
            Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
        }
    }

    public void InstantiateImpact(Vector3 position)
    {
        if (impactPrefab)
        {
            Instantiate(impactPrefab, position, Quaternion.identity);
        }
    }
}
