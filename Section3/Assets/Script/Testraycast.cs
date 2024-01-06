using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testraycast : MonoBehaviour
{
    public LineRenderer lineRenderer;
    // Start is called before the first frame update
    void Start()
    {
        if (lineRenderer == null)
        {
            Debug.LogError("Line Renderer is not assigned.");
            return;
        }

        // Lấy thông tin của điểm đầu mút (index 0) của Line Renderer.
        Vector3 startPosition = lineRenderer.GetPosition(1);

        // In ra thông tin của điểm đầu mút.
        Debug.Log("Position of the first point: " + startPosition);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
