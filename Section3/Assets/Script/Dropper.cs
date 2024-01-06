using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    Rigidbody dropper;
    [SerializeField] float timeToWait = 5f;
    // Start is called before the first frame update
    void Start()
    {
        

        dropper=GetComponent<Rigidbody>();
        dropper.useGravity=false;
    }

    // Update is called once per frame
    public void GetDrop()
    {
        var oscillator=GetComponent<Oscillator>();
        oscillator.enabled=false;

        dropper.useGravity=true;
        Debug.Log("3 seconds has eslapsed !");
    }
}
