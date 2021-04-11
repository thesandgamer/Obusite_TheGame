using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class Scr_Capacite
{
    public string nom;
    public Text uiCapaText;
    public Text[] uiCapaAltText;
    public int intCapa;

    public Scr_Capacite(string nom, Text uiCapaText,Text[] uiCapaAltText, int intCapa)
    {
        this.nom = nom;
        this.uiCapaText = uiCapaText;
        this.uiCapaAltText = uiCapaAltText;
        this.intCapa = intCapa;

    }
    

}
