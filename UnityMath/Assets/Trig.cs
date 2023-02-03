using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trig : MonoBehaviour
{
    const float TAU = Mathf.PI * 2;
    public int dotCount = 16;

    private void OnDrawGizmos()
    {
        for(int i = 0; i < dotCount; i++)
        {
            float t = i / (float)dotCount;
            float angRad = t * TAU;

            Gizmos.DrawSphere(CreateVectorFromAngle(angRad), .06f);
            

        } 
    }

    Vector2 CreateVectorFromAngle(float radii)
    {
        float x = Mathf.Cos(radii);
        float y = Mathf.Sin(radii);

        return new Vector2(x, y);
    }

}
