using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cable : MonoBehaviour
{
    [SerializeField] private float longitude = 10f;
    public float Longitude { get { return longitude; } }
    [SerializeField] private int numPoints = 10;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform start, end;
    public Transform StartPosition { get { return start; } }
    [HideInInspector] public bool constraint = true;

    private void Start()
    {
        lineRenderer.positionCount = numPoints;
    }

    private void Update()
    {
        if (constraint && Vector3.Distance(start.position, end.position) > longitude)
            end.position = start.position + (end.position - start.position).normalized * longitude;


        //lineRenderer.SetPosition(0, start.position);

        Vector3 middle = (end.position - start.position) / 2f + start.position;

        while (Vector3.Distance(start.position, middle) + Vector3.Distance(middle, end.position) < longitude)
            middle.y -= 0.01f;

        //lineRenderer.SetPosition(1, middle);

        //lineRenderer.SetPosition(2, end.position);

        for (int i = 0; i < numPoints - 1; i++)
            lineRenderer.SetPosition(i, GetCurvePoint(start.position, middle, end.position, (float)i / (float)numPoints));

        lineRenderer.SetPosition(numPoints - 1, end.position);
    }

    public Vector3 GetCurvePoint(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 p1 = Vector3.Lerp(a, b, t);
        Vector3 p2 = Vector3.Lerp(b, c, t);
        return Vector3.Lerp(p1, p2, t);
    }

    public bool PermittedLongitude(float l)
    {
        Debug.Log(l + " <= " + longitude + " is " + (l <= longitude));
        return l <= longitude;
    }
}
