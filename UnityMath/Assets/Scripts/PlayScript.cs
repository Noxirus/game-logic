using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//Refactor this until it's nicely in libraries
[ExecuteInEditMode]
public class PlayScript : MonoBehaviour
{
    [SerializeField] Transform aTf;
    [SerializeField] Transform bTf;

    Vector3 a => aTf.position;
    Vector3 b => bTf.position;

    Vector3 displacement => b - a;

    [SerializeField] Transform normalizedATf;
    [SerializeField] Transform normalizedBTf;

    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI distanceText;
    [SerializeField] TextMeshProUGUI displacementText;
    [SerializeField] TextMeshProUGUI dotProductText;
    [SerializeField] TextMeshProUGUI angleText;

    [Range(0f, 5f)]
    [SerializeField] float offSetFromA = 1f;

    private void Start()
    {
        float angle = 0;
        angle = (Mathf.PI * 2) / 4;
        Debug.Log("4 sided: " + angle * Mathf.Rad2Deg);
        angle = Mathf.PI * 2 / 6;
        Debug.Log("6 sided: " + angle * Mathf.Rad2Deg);
    }

    private void OnDrawGizmos()
    {
        DotProductExampleIsLooking();
        LocalToWorldSpace();

        //Always has a length of one when normalized
        //Vector in direction between two points
        //Gizmos.DrawLine(a, Vector3.zero);
        //Gizmos.DrawLine(b, Vector3.zero);

        //Getting direction
        //Gizmos.color = Color.magenta;
        //Gizmos.DrawLine(a, displacement.normalized + a);

        //Midpoint
        //Gizmos.color = Color.green;
        //Gizmos.DrawSphere((a + b) / 2, .3f);

        //Offset from A
        //Vector3 aToB = displacement;
        //Vector3 aToBDirection = aToB.normalized;
        //Vector3 offSetVec = aToBDirection * offSetFromA;
        //Gizmos.DrawSphere(a + offSetVec, .2f);
    }


    float CalculateMeshSurfaceArea(Mesh mesh)
    {
        Vector3[] verts = mesh.vertices;
        int[] tris = mesh.triangles;

        float area = 0f;

        for(int i = 0; i < tris.Length; i += 3)
        {
            Vector3 a = verts[tris[i]];
            Vector3 b = verts[tris[i+1]];
            Vector3 c = verts[tris[i+2]];

            area += Vector3.Cross(b - a, c - a).magnitude;
        }

        area /= 2;

        return area;
    }

    Vector3 ReturnReflection(Vector3 rayVector, Vector3 normal)
    {
        float downWardDot = Vector3.Dot(normal, rayVector); //Projects the ray direction onto the normal, wil be negative
        Vector3 downwardVector = downWardDot * normal; //We want to convert this downward dot to a vector, we can do this by multiplying it by the normal
        //This downward vector will be half the distance of the reflection, this will give us the displacement between the ray and its refletion (once we multiply it by 2)
        Vector3 vectorBetweenRayAndReflection = downwardVector * 2;
        //This gives us the vector from the Ray to where the reflection will be, subtracting that will give us the reflection
        Vector3 reflection = rayVector - (vectorBetweenRayAndReflection);

        return reflection;
    }

    float GetDistanceBetweenTwoVectors(Vector3 a, Vector3 b)
    {
        float Distance = (a - b).magnitude; //This works
        Distance = Vector2.Distance(a, b); //Or this works

        Distance = Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2) + Mathf.Pow(a.z - b.z, 2)); //Base algorithm
        //Displacement get the vector to origin at 0
        //THEN we can use pythagoras theorem because we know the axis are straight lines, meaning the vector is the hypotenous

        //This is a different kind of Distance, used for other things
        float DistanceSq = displacement.x * displacement.x + displacement.y * displacement.y + displacement.z * displacement.z;
        DistanceSq = displacement.sqrMagnitude; //Same thing
        //The squared Distance against a squared trigger thats also squared can be much quicker, as you avoid a square root
        //DOES NOT work with distance specific checks, only for boundary checking
        //This is basically checking if the boundary check is less than or greater than

        return Distance;
    }

    float ReturnDotProduct(Vector3 a, Vector3 b)
    {
        return a.x * b.x + a.y * b.y + a.z * b.z;
    }

    private void Update()
    {
        //UI Text Display
        displacementText.text = "Displacement: " + displacement.ToString();
        distanceText.text = "Distance: " + GetDistanceBetweenTwoVectors(a, b);
        dotProductText.text = "Dot Product: " + lookness;

        //Normalized direction of single vectors from zero
        //normalizedATf.position = a / a.magnitude;
        //normalizedBTf.position = b / b.magnitude;
    }

    [Range(0, 1f)]
    [SerializeField] float precissness = .5f;
    float lookness = 0f;

    void DotProductExampleIsLooking()
    {
        Vector2 center = a;
        Vector2 playerPos = b;
        Vector2 playerLookDirection = bTf.right;

        Vector2 playerToTriggerDir = (center - playerPos).normalized;

        lookness = Vector2.Dot(playerToTriggerDir, playerLookDirection);
        bool isLooking = lookness >= precissness;

        Gizmos.color = isLooking ? Color.green : Color.red;
        Gizmos.DrawLine(playerPos, playerPos + playerToTriggerDir);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(playerPos, playerPos + playerLookDirection);

        float dot = Vector2.Dot(playerToTriggerDir.normalized, playerLookDirection.normalized);
        float angle = Mathf.Acos(dot);
        angleText.text = "Angle: " + Mathf.Rad2Deg * angle;

    }

    [Header("Local to world")]
    [SerializeField] Vector2 localSpacePoint;
    [SerializeField] TextMeshProUGUI m_DescriptionText;
    void LocalToWorldSpace()
    {
        Vector2 objPos = a;
        Vector2 right = aTf.right;
        Vector2 up = aTf.up;

        Vector2 LocalToWorld(Vector2 localPt)
        {
            Vector2 worldOffset = right * localPt.x + up * localPt.y; //This is to take rotation into account
            m_DescriptionText.text = "X: " + right + "/ " + localPt.x + "= " + (right * localPt.x);

            //aTf.TransformPoint(localPt); Built in matrix multiplication to get this value

            return (Vector2)a + worldOffset;
        }


        Vector2 WorldToLocal(Vector2 worldPt)
        {
            Vector2 relativePoint = worldPt - (Vector2)a;

            float x = Vector2.Dot(relativePoint, right);
            float y = Vector2.Dot(relativePoint, up);

            //aTf.InverseTransformPoint(worldPt); Built in matrix multiplication to get this value

            return new Vector2(x, y);
        }

        Vector2 worldSpacePoint = LocalToWorld(localSpacePoint);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(worldSpacePoint, .1f);
    }
}
