using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class Laser_RayDetected : MonoBehaviour
{
    public float maxDistance = 5.0f;    
    public LineRenderer lineRenderer; 
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
            // Lấy đối tượng mà tia va chạm.
            GameObject hitObject = hitInfo.collider.gameObject;

            // Kiểm tra nếu đối tượng va chạm là đối tượng "Enemy".
            if (hitObject.CompareTag("Player"))
            {
                // Xử lý va chạm giữa Player và Enemy ở đây.
                var handle = hitObject.GetComponent<CollisionHanlder>();
                if(handle != null)
                {
                    handle.StarCrashSequence();

                }
            }
        }
    }
    // private void OnDrawGizmos()
    // {
    //     Vector3 startPosition = lineRenderer.GetPosition(0);
    //     Vector3 endPosition = lineRenderer.GetPosition(1);
    //     maxDistance = (startPosition - endPosition).magnitude;
    //     Gizmos.color = Color.red; // Màu của tia Raycast
    //     // sai r . phai nhu the nay chu .. ve tu diem dau den diem cuoi 
    //   //  Gizmos.DrawRay(startPosition,  endPosition); // call dc  ko . de giai thich. kcall dc. cầm kéo 2 đầu line thì cái đường vẽ phải song song chứ
    //     // a thay dau co sai dau
    // Gizmos.DrawSphere(startPosition,1f);
    // Gizmos.color = Color.yellow;
    // Gizmos.DrawSphere(endPosition,1f);
    // // cai duong line do o duoi , script nao ve the ? đó là object line
    // // ua sao no bi cong v . .material co van de a`
    // }
}
