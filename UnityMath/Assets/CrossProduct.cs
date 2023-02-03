using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CrossProduct : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Vector3 headPos = transform.position;
        Vector3 lookDir = transform.forward;

        void DrawRay(Vector3 pos, Vector3 dir) => Handles.DrawAAPolyLine(pos, pos + dir);

        

        if(Physics.Raycast(headPos, lookDir, out RaycastHit hit))
        {
            Vector3 hitPos = hit.point;
            Vector3 up = hit.normal;
            Vector3 right = Vector3.Cross(up, lookDir).normalized;
            Vector3 forward = Vector3.Cross(right, up);

            CreateBoundingBox(hitPos, forward, up);

            Handles.color = Color.white;
            Handles.DrawAAPolyLine(headPos, hitPos);
            Handles.color = Color.green;
            DrawRay(hitPos, up);
            Handles.color = Color.red;
            DrawRay(hitPos, right);
            Handles.color = Color.cyan;
            DrawRay(hitPos, forward);
            Handles.color = Color.magenta;
            DrawRay(hitPos, Reflection(lookDir, hit.normal));
        }
        else
        {
            Handles.color = Color.red;
            DrawRay(headPos, lookDir);
        }
    }

    public Vector3 Reflection(Vector3 ray, Vector3 normal)
    {
        return ray - 2 * (Vector3.Dot(ray, normal.normalized) * normal.normalized);
    }

    float boxSize = .5f;

    void CreateBoundingBox(Vector3 hitPos, Vector3 forward, Vector3 up)
    {
        Quaternion turretRot = Quaternion.LookRotation(forward, up);
        Matrix4x4 turretToWorld = Matrix4x4.TRS(hitPos, turretRot, Vector3.one);
 
        //Box Dimensions
        Vector3[] pts = new Vector3[]
        {
            new Vector3(boxSize, 0, boxSize),
            new Vector3(-boxSize, 0, boxSize),
            new Vector3(-boxSize, 0, -boxSize),
            new Vector3(boxSize, 0, -boxSize),
            new Vector3(boxSize, boxSize * 2, boxSize),
            new Vector3(-boxSize, boxSize * 2, boxSize),
            new Vector3(-boxSize, boxSize * 2, -boxSize),
            new Vector3(boxSize, boxSize * 2, -boxSize),
        };

        Gizmos.matrix = turretToWorld;

        Gizmos.color = Color.red;
        for(int i = 0; i < pts.Length; i++)
        {
            //Vector3 worldPt = turretToWorld.MultiplyPoint3x4(pts[i]);

            Gizmos.DrawSphere(pts[i], 0.075f);
        }

        Gizmos.matrix = Matrix4x4.identity;
    }
}
