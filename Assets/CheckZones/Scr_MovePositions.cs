using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_MovePositions : MonoBehaviour
{

    public GameObject owner;

    public Transform actualPosition;

    public Transform[] pos;

    public Scr_PositionsManager posManager;

    public Transform capaciteSpritePos;
    public GameObject capaciteSprite;


    public void SetPos(Transform[] positions)
    {
        //Get le bloc de position, puis get le bloc de positions en fonction de qui il est, puis on set toutes les pos avec les pos du bloc 
        pos = positions;
        //owner.transform.position = new Vector3(pos[0].transform.position.x, owner.transform.position.y, owner.transform.position.z);
        int i = Random.Range(0, 4);
        MoveToPosition(pos[i]);
        
    }
  

    public void MoveToPosition(Transform pos)
    {
        if (actualPosition != pos)
        {
            actualPosition = pos;
            owner.transform.position = new Vector3(pos.transform.position.x, owner.transform.position.y, pos.transform.position.z + 1);
            Debug.Log("Move");
        }
        
    }

    public void SetSpriteCapaTransform()
    {
        capaciteSprite.transform.position = capaciteSpritePos.transform.position;
    }


}
