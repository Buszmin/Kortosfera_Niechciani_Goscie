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
            Instantiate(plusPointsPrefab).transform.position = transform.position;
            spriteRenderer.sprite = hitSprite;
        }
    }
}
