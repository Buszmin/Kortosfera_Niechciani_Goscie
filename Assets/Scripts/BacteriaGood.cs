using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaGood : Bacteria
{   protected override void Start()
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
    }
}
