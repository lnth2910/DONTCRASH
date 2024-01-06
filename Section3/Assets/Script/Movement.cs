using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float mainThrust = 100f;
    [SerializeField] private float rotateThrust = 100f;
    [SerializeField] ParticleSystem slideThrust;
    [SerializeField] ParticleSystem rightThrust;
    [SerializeField] ParticleSystem leftThrust;    
    // Start is called before the first frame update
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate(); 
    }

    //Điều khiển tên lửa

    //Tạo lực đẩy tên lửa
    void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }
    //Bắt đầu đẩy
    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!slideThrust.isPlaying)
        {
            slideThrust.Play();
        }
    }
    //Dừng đẩy
    void StopThrusting()
    {
        slideThrust.Stop();
    }
    
    //Điều khiển hướng tên lửa

    //Xoay tên lửa
    void ProcessRotate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }

        else if(Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }

        else
        {
            StopRotating();
        }
    }
        //Xoay trái
    void RotateLeft()
    {
        ApplyRotate(rotateThrust);
        if (!rightThrust.isPlaying)
        {
            rightThrust.Play();
        }
    }
    //Xoay phải
    void RotateRight()
    {
        ApplyRotate(-rotateThrust);
        if (!leftThrust.isPlaying)
        {
            leftThrust.Play();
        }
    }
    //Dừng xoay
    void StopRotating()
    {
        rightThrust.Stop();
        leftThrust.Stop();
    }
    //Điều chỉnh hướng xoay
    public void ApplyRotate( float rotateValue)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotateValue * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
