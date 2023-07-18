using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    [SerializeField] TextMeshPro text;
    private void Start()
    {
        StartCoroutine(waitToDestory());
    }      

    public void Init(int value)
    {
        if(value < 0)
            text.text = value.ToString();
        else
            text.text = "+" + value.ToString();

        TimePointsManager.Instance.UpdatePoints(value);
    }

    IEnumerator waitToDestory()
    {
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }
}
