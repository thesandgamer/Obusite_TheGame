using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Scr_CapaAllAuto
{
    public string name;
    public Scr_AutoCapa[] autoCapa;
    public Sprite capaTypeSprite;

    public Scr_CapaAllAuto(string name, Scr_AutoCapa[] autoCapa, Sprite capaTypeSprite)
    {
        this.name = name;
        this.autoCapa = autoCapa;
        this.capaTypeSprite = capaTypeSprite;
    }

}



