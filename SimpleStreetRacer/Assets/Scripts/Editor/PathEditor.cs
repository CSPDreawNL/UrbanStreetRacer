using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(PathCreator))]
public class PathEditor : Editor
{
    PathCreator pathCreator;
    Path path;

    void OnSceneGUI()
    {
        Draw();
    }

    void Draw()
    {
        for (int i = 0 ; i < path.NumberSegments ; i++)
        {
            Vector3[] points = path.GetPointsInSegment(i);
            Handles.color = Color.black;
            Handles.DrawLine(points[1], points[0]);
            Handles.DrawLine(points[2], points[3]);
            Handles.DrawBezier(points[0], points[3], points[1], points[2], Color.green, null, 2);
        }

        Handles.color = Color.red;
        for (int i = 0 ; i < path.NumberPoints ; i++)
        {
            Vector3 newPos = Handles.FreeMoveHandle(path[i], Quaternion.identity, 0.1f, Vector3.zero, Handles.CylinderHandleCap);
            if (path[i] != newPos)
            {
                Undo.RecordObject(pathCreator, "Move point");
                path.MovePoint(i, newPos);
            }
        }
    }

    private void OnEnable()
    {
        pathCreator = (PathCreator)target;
        if (pathCreator.path == null)
        {
            pathCreator.CreatePath();
        }
        path = pathCreator.path;
    }
}
