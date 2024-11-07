using UnityEngine;

public enum LoopType
{
    None,
    Normal,
    PingPong
}

public class WaypointsPath : MonoBehaviour
{
    public LoopType loopType;
    public float waitTimeInEachPoint = 0.5f;
    public Transform[] patrolPoints;

    private int _currentPointIndex;
    private int _nextPointDelta = 1;
    private float _waitTimer = 0f;

    public Vector3 TargetPoint => patrolPoints[_currentPointIndex].position;

    public void MoveTowardsPatrolPoints(Transform source, float speed)
    {
        if (patrolPoints.Length <= 1) return;

        source.position = Vector3.MoveTowards(source.position, TargetPoint, Time.deltaTime * speed);

        CalculateNextPoint(source);
    }

    private void CalculateNextPoint(Transform source)
    {
        if (Vector3.Distance(source.position, TargetPoint) < 0.1f)
        {
            _waitTimer += Time.deltaTime;

            if (_waitTimer < waitTimeInEachPoint)
                return;

            _currentPointIndex += _nextPointDelta;

            switch (loopType)
            {
                case LoopType.None:
                    if (_currentPointIndex >= patrolPoints.Length)
                        _currentPointIndex = patrolPoints.Length - 1;
                    else if (_currentPointIndex == -1)
                        _currentPointIndex = 0;
                    break;
                case LoopType.Normal:
                    if (_currentPointIndex == -1)
                    {
                        _currentPointIndex = patrolPoints.Length - 1;
                    }
                    _currentPointIndex %= patrolPoints.Length;

                    // Length = 4
                    // 0 % 4 = 0; 1 % 4 = 1; 2 % 4 = 2; 3 % 4 = 3
                    // 4 % 4 = 0; 5 % 4 = 1; 6 % 4 = 2; 7 % 4 = 3
                    break;
                case LoopType.PingPong:
                    if (_currentPointIndex >= patrolPoints.Length)
                    {
                        _currentPointIndex = patrolPoints.Length - 2;
                        _nextPointDelta = -1;
                    }
                    else if (_currentPointIndex < 0)
                    {
                        _currentPointIndex = 1;
                        _nextPointDelta = +1;
                    }

                    break;
            }
        }
        else
        {
            _waitTimer = 0;
        }
    }

    void OnDrawGizmos()
    {
        if (patrolPoints == null || patrolPoints.Length == 0) return;

        for (int i = 0; i < patrolPoints.Length; i++)
        {
            if (i != patrolPoints.Length - 1)
            {
                Debug.DrawLine(patrolPoints[i].position, patrolPoints[i + 1].position, Color.red);
            }
        }
    }
}
