using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace USR.BezierCurve
{


    [CustomEditor(typeof(Line))]
    public class LineInspector : Editor
    {
        private void OnSceneGUI()
        {
            Line line = target as Line;
            Transform handleTransform = line.transform;
            Quaternion handlerotation = Tools.pivotRotation == PivotRotation.Local ? handleTransform.rotation : Quaternion.identity;
            Vector3 p0 = handleTransform.TransformPoint(line.p0);
            Vector3 p1 = handleTransform.TransformPoint(line.p1);

            Handles.color = Color.red;
            Handles.DrawLine(p0, p1);
            Handles.DoPositionHandle(p0, handlerotation);
            Handles.DoPositionHandle(p1, handlerotation);

            EditorGUI.BeginChangeCheck();
            p0 = Handles.DoPositionHandle(p0, handlerotation);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(line, "Move Point");
                EditorUtility.SetDirty(line);
                line.p0 = handleTransform.InverseTransformPoint(p0);
            }
            EditorGUI.BeginChangeCheck();
            p1 = Handles.DoPositionHandle(p1, handlerotation);
            if (EditorGUI.EndChangeCheck())
            {
                Undo.RecordObject(line, "Move Point");
                EditorUtility.SetDirty(line);
                line.p1 = handleTransform.InverseTransformPoint(p1);
            }
        }
    }
}
