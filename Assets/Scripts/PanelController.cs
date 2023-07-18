using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    bool skipUnlocked;
    [SerializeField] private GameObject activePanel;
    [SerializeField] private GameObject nextPanel;

    private void OnEnable()
    {
        StartCoroutine(waitToUnlock()); 
    }

    private void Update()
    {
        if (Input.anyKey && skipUnlocked)
        {
            skipUnlocked = false;
            activePanel.SetActive(false);
            nextPanel.SetActive(true);
        }
    }

    IEnumerator waitToUnlock()
    {
        yield return new WaitForSeconds(2f);
        skipUnlocked = true;
    }
}
