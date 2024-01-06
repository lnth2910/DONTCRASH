using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper_RayDetected : MonoBehaviour
{
    public float maxDistance = 5.0f;
    public GameObject dropper;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 originPosition = transform.position;
        // Xác định hướng của tia (ví dụ: hướng xuống).
        Vector3 direction = Vector3.down;
        Ray ray = new Ray(originPosition, direction);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, maxDistance))
        {
            Debug.Log("da cham");
            // Lấy đối tượng mà tia va chạm.
            GameObject hitObject = hitInfo.collider.gameObject;

            // Kiểm tra nếu đối tượng va chạm là đối tượng "Enemy".
            if (hitObject.CompareTag("Player"))
            {
                Debug.Log("roi di");
                // Xử lý va chạm giữa Player và Enemy ở đây.
                var handle = dropper.GetComponent<Dropper>();
                if(handle != null)
                {
                    handle.GetDrop();

                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // Màu của tia Raycast
        Gizmos.DrawRay(transform.position, Vector3.down*30);
    }
    
}
