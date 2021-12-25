using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float test;
    void Start()
    {
        LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.SetWidth(0.1F, 0.1F);
        lineRenderer.SetVertexCount(51);;
        // lineRenderer.material = 
    }
    
    public Vector3 P1;
    public Vector3 P2;
    public Vector3 P3;
    public Vector3 P4;
    
    private void Update()
    {
        LineRenderer lineRenderer = GetComponent<LineRenderer>();
        Vector3[] points = new Vector3[51];
        float value;
        for (int i = 0; i <= 50; i++)
        {
            value = (float)i / 50;
            points[i] = BezierTest(P1, P2, P3, P4, value);
            // points[i] = (P4 - P1) * i + P1;
        }
        lineRenderer.SetPositions(points);
    }

    public Vector3 BezierTest(
        Vector3 P_1,
        Vector3 P_2,
        Vector3 P_3,
        Vector3 P_4,
        float Value
        )
    {
        Vector3 A = Vector3.Lerp(P_1, P_2, Value);
        Vector3 B = Vector3.Lerp(P_2, P_3, Value);
        Vector3 C = Vector3.Lerp(P_3, P_4, Value);

        Vector3 D = Vector3.Lerp(A, B, Value);
        Vector3 E = Vector3.Lerp(B, C, Value);

        Vector3 F = Vector3.Lerp(D, E, Value);

        return F;
    }
}
