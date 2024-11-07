using UnityEngine;

[RequireComponent(typeof(ProjectileMovement), typeof(DamageStat))]
public class Projectile : MonoBehaviour
{
    [Header("References")]
    public GameObject muzzlePrefab;
    public GameObject impactPrefab;

    [Header("SFX")]
    public AudioClip shootClip;
    public AudioClip impactClip;

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

        if (shootClip)
        {
            AudioManager.Instance.PlayAudio(shootClip, AudioType.SFX, transform.position);
        }
    }

    public void InstantiateImpact(Vector3 position)
    {
        if (impactPrefab)
        {
            Instantiate(impactPrefab, position, Quaternion.identity);
        }

        if (impactClip)
        {
            AudioManager.Instance.PlayAudio(impactClip, AudioType.SFX, transform.position);
        }
    }
}
