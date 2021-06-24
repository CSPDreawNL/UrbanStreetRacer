using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Path : MonoBehaviour
{
    [SerializeField, HideInInspector]
    List<Vector3> points;

    public Path(Vector3 centre)
    {
        points = new List<Vector3>
        {
            centre + Vector3.left,
            centre + (Vector3.left + Vector3.up) * 0.5f,
            centre + (Vector3.right + Vector3.down) * 0.5f,
            centre + Vector3.right
        };
    }

    public Vector3 this[int index]
    {
        get
        {
            return points[index];
        }
    }

    public int NumberPoints 
    {
        get
        {
            return points.Count;
        }
    }

    public int NumberSegments
    {
        get
        {
            return (points.Count - 4) / 3 + 1;
        }
    }

    public void AddSegment (Vector3 anchorPos)
    {
        points.Add(points[points.Count - 1] * 2 - points[points.Count - 2]);
        points.Add((points[points.Count - 1] + anchorPos) * 0.5f);
        points.Add(anchorPos);
    }

    public Vector3[] GetPointsInSegment(int index)
    {
        return new Vector3[]
        {
            points[index * 3], points[index * 3 + 1], points[index * 3 + 2], points[index * 3 + 3]
        };
    }

    public void MovePoint(int index, Vector3 pos)
    {
        points[index] = pos;
    }

}
