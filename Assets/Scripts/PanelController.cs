using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    bool skipUnlocked;
    [SerializeField] private GameObject activePanel;
    [SerializeField] private GameObject nextPanel;

    [SerializeField] private bool isLastPanel;
    [SerializeField] private GameObject firstPanel;
    [SerializeField] private Animation anim;

    private void OnEnable()
    {
        StartCoroutine(waitToUnlock()); 

        if(isLastPanel)
        {
            StartCoroutine(waitToRestart());
        }
    }

    private void Update()
    {
        if (Input.anyKey && skipUnlocked)
        {
            anim.Play(anim.clip.name);
            StopAllCoroutines();
            StartCoroutine(waitForAnim());
        }
    }

    IEnumerator waitToUnlock()
    {
        yield return new WaitForSeconds(2f);
        skipUnlocked = true;
    }

    IEnumerator waitToRestart()
    {
        yield return new WaitForSeconds(30f);

        skipUnlocked = false;
        activePanel.SetActive(false);
        firstPanel.SetActive(true);
        StopAllCoroutines();
    }

    IEnumerator waitForAnim()
    {
        yield return new WaitForSeconds(0.24f);

        skipUnlocked = false;
        activePanel.SetActive(false);
        nextPanel.SetActive(true);
    }
}
