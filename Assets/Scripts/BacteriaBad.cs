using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BacteriaBad : Bacteria
{
    [SerializeField] private int health;

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
        Instantiate(minusPointsPrefab).transform.position = transform.position;
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
                Instantiate(plusPointsPrefab).transform.position = transform.position;
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
