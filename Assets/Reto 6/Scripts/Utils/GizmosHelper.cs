using UnityEngine;

public class GizmosHelper : MonoBehaviour
{
    public static void DrawCircle2D(Vector3 center, float radius, Color color, int segments = 36)
    {
        Color prevColor = Gizmos.color;
        Gizmos.color = color;

        // Número de segmentos para definir la suavidad del círculo
        float angleStep = 360f / segments;

        Vector3 prevPoint = center + new Vector3(Mathf.Cos(0) * radius, Mathf.Sin(0) * radius, 0);

        // Dibujamos línea por línea para formar el círculo
        for (int i = 1; i <= segments; i++)
        {
            float angle = angleStep * i * Mathf.Deg2Rad;
            Vector3 newPoint = center + new Vector3(Mathf.Cos(angle) * radius, Mathf.Sin(angle) * radius, 0);

            Gizmos.DrawLine(prevPoint, newPoint);
            prevPoint = newPoint;
        }

        Gizmos.color = prevColor;
    }
}
