using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Scr_CapaAllItems
{
    public string name;
    public Scr_AutoCapa[] autoCapa;
    public Scr_AttackCapa[] attackCapa;
    public Sprite capaTypeSprite;

    public Scr_CapaAllItems(string name, Scr_AutoCapa[] autoCapa, Scr_AttackCapa[] attackCapa,Sprite capaTypeSprite)
    {
        this.name = name;
        this.autoCapa = autoCapa;
        this.attackCapa = attackCapa;
        this.capaTypeSprite = capaTypeSprite;

}
}
