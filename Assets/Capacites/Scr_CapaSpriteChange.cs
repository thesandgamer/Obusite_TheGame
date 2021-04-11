using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_CapaSpriteChange : MonoBehaviour
{
    public Scr_AttackVisualClass[] AttackVisual;

    public GameObject uiToHide;

    GameObject spriteRender;

    public Transform capaciteSpritePos;

    private void Start()
    {
        if (this.CompareTag("Player"))
        {
            Scr_ClickOnObjectInScne.capaciteEnd += ResetSprite;
            Scr_ClickOnObjectInScne.capaciteStart += SwitchSprite;
        }
        else if (this.CompareTag("Ennemi"))
        {
            Scr_Ennemi.ennemiCapaEnd += ResetSprite;
            Scr_Ennemi.ennemiCapaStart += SwitchSprite;
        }

    }



    public void SwitchSprite(string name)
    {
        if (uiToHide != null) uiToHide.SetActive(false);
        Debug.Log("name: " + name);
        if (this.CompareTag("Player"))
        {
            switch (name)
            {

                //Coup de baionette
                case "Poignardage":
                    ChangeSprite(0);
                    break;

                case "Evicération":
                    ChangeSprite(0);
                    break;
                
                case "Efleurement":
                    ChangeSprite(0);
                    break;

                //Coup de crosse
                case "Coup":
                    ChangeSprite(1);
                    break;
                
                case "Brisage":
                    ChangeSprite(1);
                    break;
                
                case "Pousser":
                    ChangeSprite(1);
                    break;

                //Tir

                case "Tir normal":
                    ChangeSprite(2);
                    break;

                //Autre
                case "Calmant":
                    ChangeSprite(3);
                    break;

                case "Grenade étourdissante":
                    ChangeSprite(4);
                    break;

                case "Viser":
                    ChangeSprite(5);
                    break;
                
                case "Soin":
                    ChangeSprite(6);
                    break;




                default:
                    break;

            }
        }
        else if (this.CompareTag("Ennemi"))
        {
            switch (name)
            {
                case "Tir normal":
                    ChangeSprite(0);
                    break;

                case "Coup":
                    ChangeSprite(1);
                    break;
                
                case "Coup Pelle":
                    ChangeSprite(2);
                    break;

                case "Tir pistolet":
                    ChangeSprite(3);
                    break;

                case "Coup dague":
                    ChangeSprite(4);
                    break;


                default:
                    break;

            }
        }



    }

    public void ResetSprite()
    {
        Destroy(spriteRender);
        if (uiToHide != null)  uiToHide.SetActive(true);
    }
    
    public void ChangeSprite(int i)
    {
        //spriteRenderer.sprite = AttackVisual[i].image;
        // gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = AttackVisual[i].fx;
        if (AttackVisual[i].image != null)
        {
            spriteRender = Instantiate(this.AttackVisual[i].image, transform.position, transform.rotation, transform);
        }
        
    }


    public void SetSpriteCapaTransform()
    {
        transform.position = capaciteSpritePos.transform.position;
    }


    private void OnDisable()
    {
        if (this.CompareTag("Player"))
        {
            Scr_ClickOnObjectInScne.capaciteStart -= SwitchSprite;
            Scr_ClickOnObjectInScne.capaciteEnd -= ResetSprite;
        }
        else if (this.CompareTag("Ennemi"))
        {
            Scr_Ennemi.ennemiCapaStart -= SwitchSprite;
            Scr_Ennemi.ennemiCapaEnd -= ResetSprite;
        }
    }



}