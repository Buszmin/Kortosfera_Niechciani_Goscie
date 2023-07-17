using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField, Range(0, 0.1f)] private float speed = 0.1f;

    void FixedUpdate()
    {
        transform.position = transform.position + Vector3.up * speed;
        StartCoroutine(waitToDestory());
    }

    IEnumerator waitToDestory()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
