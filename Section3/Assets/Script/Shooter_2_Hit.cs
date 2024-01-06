using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter_2_Hit : MonoBehaviour
{
    [SerializeField] ParticleSystem hitParticals;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        // Xử lý va chạm với enemy.
        if (other.gameObject.tag == "Bullet")
        {
            // Xử lý va chạm với enemy tại đây (ví dụ: giảm điểm, gây sát thương cho enemy, vv.)
                      
            // Hủy bỏ viên đạn sau khi va chạm với enemy.
            
            hitParticals.Play();
        }
    }
}
