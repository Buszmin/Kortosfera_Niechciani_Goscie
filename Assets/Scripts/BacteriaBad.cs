using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaBad : Bacteria
{
    [SerializeField] private int health;
    [SerializeField] private bool big;

    protected override void Start()
    {
        base.Start();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    protected override void TouchFinishLine()
    {
        Debug.Log("Punkty minusowe");
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
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Bullet>() != null)
        {
            Destroy(collision.gameObject);
            health--;
            spriteRenderer.sprite = hitSprite;
            if (health <= 0)
            {
                Die();
                GameObject point = Instantiate(plusPointsPrefab);
                point.transform.position = transform.position;

                if (big)
                {
                    point.GetComponent<Points>().Init(10);
                }
                else
                {
                    point.GetComponent<Points>().Init(5);
                }
            }
            StartCoroutine(changeToNormalSprite());
        }
    }

    IEnumerator changeToNormalSprite()
    {
        yield return new WaitForSeconds(1f);
        spriteRenderer.sprite = baseSprite;
    }
}
