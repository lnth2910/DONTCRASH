using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BulletMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    public float bulletLifetime = 5.0f;
    // Start is called before the first frame update
    
    void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }

    // Update is called once per frame
    void Update()
    {
        float xValue = Time.deltaTime*moveSpeed;
        transform.Translate(0,xValue,0);
    }

    void OnCollisionEnter(Collision other)
    {
        // Xử lý va chạm với enemy.
        if (other.gameObject)
        {
            // Xử lý va chạm với enemy tại đây (ví dụ: giảm điểm, gây sát thương cho enemy, vv.)
                      
            // Hủy bỏ viên đạn sau khi va chạm với enemy.
            
            Destroy(gameObject);
        }
    }
}
