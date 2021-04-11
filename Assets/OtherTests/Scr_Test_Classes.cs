using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class WeaponStats
{
    public string name;
    public float fireRate;
    public int ammoCount;

    public WeaponStats(string name, float fireRate, int ammoCount)
    {
        //Initialisation
        this.name = name;
        this.fireRate = fireRate;
        this.ammoCount = ammoCount;
    }

}

public class Scr_Test_Classes : MonoBehaviour
{

    private WeaponStats blaster;
    private WeaponStats rockets;

    void Stat()
    {
        blaster = new WeaponStats("Blaster", 0.25f, 50);
        rockets = new WeaponStats("Rockets", 5f, 1);

        Debug.Log("Current weapon Name " + blaster.name);
    }

}
