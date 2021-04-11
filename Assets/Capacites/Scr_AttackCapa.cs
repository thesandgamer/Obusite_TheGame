using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class Scr_AttackCapa
{
    public string name;
    public Sprite icone;
    public int moralRequire;
    public bool[] portee;
    public int[] modifPortee;
    public int nbCibles;
    public int touche;
    public int[] degats;
    public UnityEvent effet;


    public Scr_AttackCapa(string name, Sprite icone,int moralRequire ,bool[] portee, int[] modifPortee,int nbCibles,int touche, int[] degats,UnityEvent effet)
    {
        this.name = name;
        this.icone = icone;
        this.moralRequire = moralRequire;
        this.portee = portee;
        this.modifPortee = modifPortee;
        this.nbCibles = nbCibles;
        this.touche = touche;
        this.degats = degats;
        this.effet = effet;

    }

    public void Active()
    {
        Debug.Log(name);
    }


}
