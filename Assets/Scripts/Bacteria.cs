using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacteria : MonoBehaviour
{
    [SerializeField, Range(0, 0.1f)] private float speed = 0.1f;
    [SerializeField] private float finishLineY = -0.3f;
    [SerializeField] protected Sprite baseSprite;
    [SerializeField] protected Sprite hitSprite;
    [SerializeField] protected GameObject plusPointsPrefab;
    [SerializeField] protected GameObject minusPointsPrefab;
    protected SpriteRenderer spriteRenderer;
    protected Collider2D collider;
    protected Animation DieAnim;
    bool behindFinishLine;
    protected bool died;

    protected virtual void Start()
    {
        transform.Rotate(0, 0, Random.Range(0.0f, 360.0f));
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider = GetComponent<Collider2D>();
        DieAnim = GetComponent<Animation>();
    }

    protected virtual void FixedUpdate()
    {
        transform.position = transform.position + Vector3.down * speed;

        if (transform.position.y < finishLineY && !behindFinishLine && !died)
        {
            behindFinishLine = true;
            TouchFinishLine();
        }
    }

    protected void Die()
    {
        died = true;
        collider.enabled = false;
        DieAnim.Play(DieAnim.clip.name);
        StartCoroutine(waitToDestory());
    }

    IEnumerator waitToDestory()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(gameObject);
    }

    protected virtual void TouchFinishLine(){}
}
