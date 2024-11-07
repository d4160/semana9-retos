using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float speed = 3.1f;
    public float fieldOfViewSize = 5f;

    [Header("References")]
    public Transform target;
    public WaypointsPath waypointsPath;

    void Update()
    {
        if (waypointsPath)
            waypointsPath.MoveTowardsPatrolPoints(transform, speed);

        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        if (Vector3.Distance(transform.position, target.position) < fieldOfViewSize)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed * 1.5f);
        }
    }

    void OnDrawGizmos()
    {
        GizmosHelper.DrawCircle2D(transform.position, fieldOfViewSize, Color.yellow);
    }
}
