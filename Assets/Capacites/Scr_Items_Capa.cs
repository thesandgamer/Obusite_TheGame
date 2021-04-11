using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]

public class Scr_Items_Capa
{
    public string nom;
    public Text uiCapaText;
    public int intCapa;
    public int number;

    public Scr_Items_Capa(string nom, Text uiCapaText, int intCapa,int number)
    {
        this.nom = nom;
        this.uiCapaText = uiCapaText;
        this.intCapa = intCapa;
        this.number = number;

    }
}
