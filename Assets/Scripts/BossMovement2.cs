using UnityEngine;

public class BossMovement2 : MonoBehaviour
{
    public float speed = 3.1f;
    public Transform areaCenter;
    public bool useCircularArea = true;
    public float circleRadius = 10f;
    public Vector2 rectangleSize = new Vector2(10, 5);
    public float waitTimeInEachPoint = 1f;

    private Vector3 _targetPoint;
    private float _waitTimer = 0f;

    void Start()
    {
        CalculateTargetPoint();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPoint, Time.deltaTime * speed);

        if (Vector3.Distance(transform.position, _targetPoint) < 0.1f)
        {
            _waitTimer += Time.deltaTime;

            if (_waitTimer < waitTimeInEachPoint)
                return;

            CalculateTargetPoint();
        }
        else
        {
            _waitTimer = 0;
        }
    }

    private void CalculateTargetPoint()
    {
        if (useCircularArea)
        {
            _targetPoint = new Vector3(Random.insideUnitCircle.x, Random.insideUnitCircle.y, 0) * circleRadius + areaCenter.position;
        }
        else
        {
            float randomX = Random.Range(-rectangleSize.x / 2, rectangleSize.x / 2);
            float randomY = Random.Range(-rectangleSize.y / 2, rectangleSize.y / 2);
            _targetPoint = areaCenter.position + new Vector3(randomX, randomY, 0);
        }
    }

    void OnDrawGizmos()
    {
        if (useCircularArea)
        {
            GizmosHelper.DrawCircle2D(areaCenter.position, circleRadius, Color.cyan);
        }
        else
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireCube(areaCenter.position, new Vector3(rectangleSize.x, rectangleSize.y, 0));
        }
    }
}