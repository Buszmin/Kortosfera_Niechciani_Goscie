using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [Header("Movement")]
    [SerializeField, Range(0,0.1f) ] private float speed;
    [SerializeField] private float movmentRange;

    [Header("Shooting")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shootTimer;
    private bool canShoot = true;

    [Header("Collecting")]
    [SerializeField] private GameObject outlineCollectorObj;
    [SerializeField] private float outlineTimer;
    private bool canCollect = true;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            if (player.transform.position.x < movmentRange)
            {
                player.transform.position = player.transform.position + Vector3.right * speed;
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (player.transform.position.x > -movmentRange)
            {
                player.transform.position = player.transform.position + Vector3.left * speed;
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (canShoot)
            {
                Shoot();
            }
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (canCollect)
            {
                Collect();
            }
        }
    }

    private void Shoot()
    {
        canShoot = false;
        GameObject newBullet = Instantiate(bulletPrefab);
        newBullet.transform.position = transform.position;
        StartCoroutine(ShootWait());
    }

    IEnumerator ShootWait()
    {
        yield return new WaitForSeconds(shootTimer);
        canShoot = true;
    }

    private void Collect()
    {
        canCollect = false;
        outlineCollectorObj.SetActive(true);
        StartCoroutine(CollectWait());
    }

    IEnumerator CollectWait()
    {
        yield return new WaitForSeconds(outlineTimer / 2);
        outlineCollectorObj.SetActive(false);
        yield return new WaitForSeconds(outlineTimer / 2);
        canCollect = true;
    }
}
