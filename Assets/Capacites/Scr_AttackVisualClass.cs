using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scr_AttackVisualClass 
{
    public string name;
    public GameObject image;

    public Scr_AttackVisualClass(string name, GameObject image)
    {
        this.name = name;
        this.image = image;
    }

}
