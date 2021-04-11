using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Scr_CapaAll 
{
    public string name;
    public Scr_AttackCapa[] attackCapa;
    public Sprite capaTypeSprite;

    public Scr_CapaAll(string name, Scr_AttackCapa[] attackCapa,Sprite capaTypeSprite)
    {
        this.name = name;
        this.attackCapa = attackCapa;
        this.capaTypeSprite = capaTypeSprite;
    }



}
