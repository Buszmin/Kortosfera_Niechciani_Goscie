using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaGood : Bacteria
{
    [SerializeField] private bool big;
    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Outline")
        {
            Die();
            GameObject point = Instantiate(plusPointsPrefab);
            point.transform.position = transform.position;
            point.GetComponent<Points>().Init(15);
            spriteRenderer.sprite = hitSprite;
        }

        if (collision.GetComponent<Bullet>() != null)
        {
            Destroy(collision.gameObject);


            Die();
            GameObject point = Instantiate(minusPointsPrefab);
            point.transform.position = transform.position;

            if (big)
            {
                point.GetComponent<Points>().Init(-10);
            }
            else
            {
                point.GetComponent<Points>().Init(-5);
            }
        }
    }
}
