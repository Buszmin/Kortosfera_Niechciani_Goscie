using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(TextMeshPro))]
public class TextScript : MonoBehaviour
{
    public enum Langugage
    {
        pl,
        en
    }

    [SerializeField] string category;
    [SerializeField] string variabels;
    [SerializeField] Langugage language;

    private void Start()
    {
 
         GetComponent<TextMeshPro>().text = TranslationManager.Instance.GetText(category, variabels, language.ToString());

    }
}
