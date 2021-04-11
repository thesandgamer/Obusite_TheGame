using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum BattleState { START, PLAYERTURN,ENEMYTURN,END,TURN }

public class Scr_TurnManager : MonoBehaviour
{
    public BattleState state;

    public GameObject player;
    public GameObject[] enemy;

    [Header ("Cameras")]
    public Camera battleCamera;
    public Camera cityCamera;

    public GameObject battleUi;

    public GameObject positionGameObject;
    public Transform positionPos;

    [Header("Capa Sprite")]
    public Transform capaSpriteToSpawnTransform;
    public Transform capaSpriteEnnemiToSpawnTransform;

    private GameObject position;

    public Scr_CapaSpriteChange[] spriteChange;

    public int ennemiInCombat;

    public static Action winEvent;

    void Start()
    {
        battleCamera.enabled = false;
        ennemiInCombat = enemy.Length;
        Scr_TakeDamages.deathEvent += CheckNumberOfEnnemiesInCombat;
        Scr_TakeDamages.playerDeath += LooseCombat;
        Scr_Ennemi.noMoralEvent += CheckNumberOfEnnemiesInCombat;
        Scr_Ennemi.endTurnEvent += OneEnnemyEndTurn;
        Scr_TakeDamages.backInCombat += EnnemiIsBack;

    }
    private void Update()
    {
        //CheckIfEnnemiMakeTurn();
        //CheckIfEnnemiIsAlive();

    }

    public void SetupBattle()
    {
        Debug.Log("---// Setup du battle \\---");

        //Get PlayerManagerCombat et on l'active
        player.transform.GetChild(1).gameObject.SetActive(true);
        //Get PlayerManagerCity et on le désactive
        player.transform.GetChild(0).gameObject.SetActive(false);

        //switch camera
        battleCamera.enabled = true;
        cityCamera.enabled = false;
        
        //on instancie le ForCombat
        position = Instantiate(positionGameObject, positionPos.position , Quaternion.identity);

        //Replace le player
        player.transform.GetChild(1).gameObject.GetComponent<Scr_MovePositions>().SetPos(position.GetComponent<Scr_PositionsManager>().playerPositions);
        //Replace le capa sprite render

        //player.transform.GetChild(1).gameObject.GetComponent<Scr_MovePositions>().capaciteSpritePos = capaSpriteToSpawnTransform.transform; 
        //player.transform.GetChild(1).gameObject.GetComponent<Scr_MovePositions>().SetSpriteCapaTransform();

        spriteChange[0].capaciteSpritePos = capaSpriteToSpawnTransform.transform;
        spriteChange[0].SetSpriteCapaTransform();
        spriteChange[1].capaciteSpritePos = capaSpriteEnnemiToSpawnTransform.transform;
        spriteChange[1].SetSpriteCapaTransform();

        FindObjectOfType<AudioManager>().Play("BattleMusic");


        //on replace les ennemis sur les pos
        for (int i =0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<Scr_MovePositions>().MoveToPosition(position.GetComponent<Scr_PositionsManager>().ennemiPositions[i]);
        }

        //Active l'Ui
        battleUi.SetActive(true);

        //Desactive l'encounter
        var collide = transform.parent.gameObject.GetComponent<SphereCollider>();
        collide.enabled = false;

        Debug.Log("Battle Start");
        state = BattleState.PLAYERTURN;

    }

    public void EnnemyTurn()
    {
        OneEnemyTour(0);
        battleUi.SetActive(false);
    }

    void OneEnemyTour(int i)
    {
        if (!enemy[i].GetComponent<Scr_TakeDamages>().dead)
        {
            if (!enemy[i].GetComponent<Scr_TakeDamages>().stun)
            {
                if (!enemy[i].GetComponent<Scr_Ennemi>().turnFinish)
                {
                    ActiveEnnemi(i);
                    i++;
                }
                else
                {
                    i++;
                    EnemyEndTurn();
                }
            }
            else
            {
                i++;
                // enemy[i].GetComponent<Scr_TakeDamages>().ResetValue();
                EnemyEndTurn();
            }
        }
        else
        {
            i++;    
            EnemyEndTurn();
        }

    }

    int ennemyMadeTurn = 0;
    void OneEnnemyEndTurn()
    {
        ennemyMadeTurn++;
        if (ennemyMadeTurn == enemy.Length)
        {
            EnemyEndTurn();
        }
        else
        {
            OneEnemyTour(ennemyMadeTurn);
        }
       
    }

    void ActiveEnnemi(int i)
    {
        enemy[i].GetComponent<Scr_Ennemi>().Turn();
        enemy[i].GetComponent<Scr_TakeDamages>().Turn();
    }

    public void PlayerTurn()
    {
        if (!player.transform.GetChild(1).GetComponent<Scr_TakeDamages>().stun)
        {
            player.transform.GetChild(1).GetComponent<Scr_ClickOnObjectInScne>().Turn();
            player.transform.GetChild(1).GetComponent<Scr_TakeDamages>().Turn();
            battleUi.SetActive(true);
        }
        else
        {
            PlayerEndTurn();
        }

    }

    public void PlayerEndTurn()
    {
        state = BattleState.ENEMYTURN;
        Debug.LogWarning("Player end turn");
        player.transform.GetChild(1).GetComponent<Scr_ClickOnObjectInScne>().playerInput.DeactivateInput();
        //Enlève le stun à la fin de son tour
        player.transform.GetChild(1).GetComponent<Scr_TakeDamages>().stun = false;
        EnnemyTurn();
    }

    public void EnemyEndTurn()
    {
        state = BattleState.PLAYERTURN;
        player.transform.GetChild(1).GetComponent<Scr_ClickOnObjectInScne>().playerInput.ActivateInput();
        Debug.LogError("Les ennemis ont fait leur tour");
        ennemyMadeTurn = 0;
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].GetComponent<Scr_TakeDamages>().UnStun();
            enemy[i].GetComponent<Scr_Ennemi>().turnFinish = false;
        }
        PlayerTurn();

    }

    int turnConteur = 0;

    public void CheckIfEnnemiMakeTurn()
    {
        
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].GetComponent<Scr_Ennemi>().turnFinish)
            {
                turnConteur++;
            }
            if (turnConteur == enemy.Length)
            {         
                enemy[i].GetComponent<Scr_Ennemi>().turnFinish = false;
                turnConteur = 0;
                //EnemyEndTurn();
                break;
            }
        }
        
    }



    
    public void CheckNumberOfEnnemiesInCombat()
    {
        ennemiInCombat--;
        if (ennemiInCombat == 0)
        {
            Debug.Log("---Plus d'ennemi");
            WinCombat();
        }
    }

    public void EnnemiIsBack()
    {
        Debug.Log("L'ENNEMI EST DESTUN");
        ennemiInCombat++;
    }



    public void CombatEnd()
    {
        Debug.Log("COMBAT END");
        state = BattleState.END;

        player.transform.GetChild(1).gameObject.SetActive(false);
        player.transform.GetChild(0).gameObject.SetActive(true);

        battleCamera.enabled = false;
        cityCamera.enabled = true;

        //
        battleUi.SetActive(false);
    }

    public void LooseCombat()
    {
        Debug.LogError("LE JOUEUR A PERDU LE COMBAT");
        position.SetActive(false);
        var collide = transform.parent.gameObject.GetComponent<SphereCollider>();
        collide.enabled = true;
        gameObject.SetActive(false);
        CombatEnd();

    }

    public void WinCombat()
    {
        Debug.LogError("LE JOUEUR A GAGNE");
        if (winEvent != null) winEvent();
        Destroy(position);
        gameObject.SetActive(false);
        Destroy(transform.parent.gameObject);
        CombatEnd();

    }




    private void OnDisable()
    {
        Scr_TakeDamages.deathEvent -= CheckNumberOfEnnemiesInCombat;
        Scr_TakeDamages.playerDeath -= LooseCombat;
        Scr_Ennemi.noMoralEvent -= CheckNumberOfEnnemiesInCombat;
        Scr_Ennemi.endTurnEvent -= OneEnnemyEndTurn;
    }

}
