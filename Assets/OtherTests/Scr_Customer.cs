using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Scr_Customer
{
    public string firstName;
    public string lastName;
    public int age;
    public string gender;
    public string occupation;

    public Scr_Customer(string first,string last,int age,string gender, string occupation)
    {
        this.firstName = first;
        this.lastName = last;
        this.age = age;
        this.gender = gender;
        this.occupation = occupation;
    }
}
