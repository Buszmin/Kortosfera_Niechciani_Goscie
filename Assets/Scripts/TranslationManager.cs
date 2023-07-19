using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationManager : MonoBehaviour
{
    [SerializeField] private TextAsset jsonFile;

    void Awake()
    {
        Root jsonRoot = JsonUtility.FromJson<Root>(jsonFile.text);

        if(jsonRoot == null)
        {
            Debug.Log("wow");
        }

        Debug.Log(jsonRoot.categories.Length);

        foreach(Category category in jsonRoot.categories)
        {
            if(category.name == "Menu")
            {
                foreach (Variable variable in category.variables)
                {
                    if (variable.name == "Tytu³")
                    {
                        foreach (Value value in variable.values)
                        {
                            Debug.Log(value.text);
                        }
                    }
                }
            }
        }
    }
}


[System.Serializable]
public class Category
{
    public string name;
    public Variable[] variables;
}

[System.Serializable]
public class Root
{
    public Category[] categories;
}

[System.Serializable]
public class Value
{
    public string text;
    public string css;
    public string lang;
}

[System.Serializable]
public class Variable
{
    public string name;
    public Value[] values;
}