using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 offset;
    Vector3 startPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Debug.Log(startPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon) { return; }
        const float tau = Mathf.PI*2;
        float cycle = Time.time / period;
        float reCycle = Mathf.Sin(tau*cycle);
        movementFactor = (reCycle + 1)/2f;
        // Debug.Log(movementFactor);

        offset = movementFactor * movementVector;
        transform.position = startPosition + offset;
    }
}
