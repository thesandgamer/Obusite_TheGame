using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CustomerDatabase : MonoBehaviour
{
    public Scr_Customer jonathan;
    public Scr_Customer luc;

    private void Start()
    {
        jonathan = new Scr_Customer("Jonahtan","Weinderger",26,"M","Ingénieur");
        luc = new Scr_Customer("Luc", "lecu", 36, "M", "Pilote");

    }

}
