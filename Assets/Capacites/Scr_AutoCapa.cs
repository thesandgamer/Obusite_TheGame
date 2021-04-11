using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class Scr_AutoCapa 
{
    public string name;
    public Sprite icone;
    public int moralRequire;
    public int touche;
    public UnityEvent effet;

    public Scr_AutoCapa(string name, Sprite icone, int moralRequire, UnityEvent effet)
    {
        this.name = name;
        this.icone = icone;
        this.moralRequire = moralRequire;
        this.effet = effet;


    }

    public void Active()
    {
        Debug.Log(name);
    }



}
