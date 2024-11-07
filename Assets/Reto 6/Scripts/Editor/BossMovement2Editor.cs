using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BossMovement2))]
public class BossMovement2Editor : Editor
{
    public override void OnInspectorGUI()
    {
        BossMovement2 bossMovement = (BossMovement2)target;

        bossMovement.speed = EditorGUILayout.FloatField("Speed", bossMovement.speed);
        bossMovement.areaCenter = (Transform)EditorGUILayout.ObjectField("Area Center", bossMovement.areaCenter, typeof(Transform), true);
        bossMovement.waitTimeInEachPoint = EditorGUILayout.FloatField("Wait Time In Each Point", bossMovement.waitTimeInEachPoint);

        bossMovement.useCircularArea = EditorGUILayout.Toggle("Use Circular Area", bossMovement.useCircularArea);

        if (bossMovement.useCircularArea)
        {
            bossMovement.circleRadius = EditorGUILayout.FloatField("Circle Radius", bossMovement.circleRadius);
        }
        else
        {
            bossMovement.rectangleSize = EditorGUILayout.Vector2Field("Rectangle Size", bossMovement.rectangleSize);
        }

        if (GUI.changed)
        {
            EditorUtility.SetDirty(bossMovement);
        }
    }
}
