using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    bool skipUnlocked;
    [SerializeField] private GameObject activePanel;
    [SerializeField] private GameObject nextPanel;

    //[SerializeField] private bool isLastPanel;
    [SerializeField] private GameObject firstPanel;
    [SerializeField] private Animation anim;
    [SerializeField] private bool isGamePanel;

    [SerializeField] private float restartTimer = 10f;

    private void OnEnable()
    {
        restartTimer = 10f;
        StartCoroutine(waitToUnlock()); 
    }

    private void Update()
    {
        restartTimer -= Time.deltaTime;

        if (Input.anyKey)
        {
            restartTimer = 10f;

            if (skipUnlocked)
            {
                anim.Play(anim.clip.name);
                StopAllCoroutines();
                StartCoroutine(waitForAnim());
            }
        }

        if(restartTimer<=0)
        {
            if (activePanel != firstPanel)
            {
                Debug.Log("Restart");
                anim.Play(anim.clip.name);
                StartCoroutine(waitforRestart());
            }
        }
    }

    IEnumerator waitToUnlock()
    {
        yield return new WaitForSeconds(2f);

        if (!isGamePanel)
        {
            skipUnlocked = true;
        }
    }

    IEnumerator waitForAnim()
    {
        yield return new WaitForSeconds(0.24f);

        skipUnlocked = false;
        activePanel.SetActive(false);
        nextPanel.SetActive(true);

        StopAllCoroutines();
    }

    IEnumerator waitforRestart()
    {
        yield return new WaitForSeconds(0.24f);

        skipUnlocked = false;
        activePanel.SetActive(false);
        firstPanel.SetActive(true);
        TimePointsManager.Instance.ClearAllBacteria();

        StopAllCoroutines();
    }
}
