using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Scr_PlayerInCity : MonoBehaviour
{
    [Header("Input Settings")]
    public PlayerInput playerInput;
    private string currentControlScheme;


    private Rigidbody rb;
    public float walkSpd = 5f;


    private void Start()
    {
        rb = transform.parent.GetComponent<Rigidbody>();   
    }
    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.parent.transform.Translate(new Vector3(-horizontal * walkSpd * Time.deltaTime,0, -vertical * walkSpd * Time.deltaTime));

    }


}
