using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_BulletSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    [SerializeField] ParticleSystem shootParticals;
    [SerializeField] float timeToWait = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObjectWithInterval());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // void SpawnBullet()
    // {
    //     // Kiểm tra xem objectToCall đã được đặt trong trình chỉnh sửa Unity.
    //     if (objectToCall != null && Time.time > timeToWait)
    //     {
    //         timeToWait++;
    //         Instantiate(objectToCall, transform.position, transform.rotation);
    //         objectToCall.SetActive(true);
    //     }
    // }

    private IEnumerator SpawnObjectWithInterval()
    {
        while (true)
        {
            Shoot();
            // Sinh ra đối tượng
            Instantiate(objectToSpawn, transform.position, Quaternion.identity);

            // Chờ trong thời gian spawnInterval
            yield return new WaitForSeconds(timeToWait);
        }
    }

    void Shoot()
    {
        shootParticals.Play();
    }
}
