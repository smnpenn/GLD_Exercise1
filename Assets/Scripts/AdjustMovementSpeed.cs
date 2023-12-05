using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdjustMovementSpeed : MonoBehaviour
{

    public LayerMask groundMask;
    public LayerMask ventMask;
    bool isGrounded;
    bool isInVent;
    public float playerHeight = 2;

    FirstPersonController controller;

    void Start()
    {
       controller = GetComponent<FirstPersonController>(); 
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, groundMask);
        isInVent = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, ventMask);

        if (isInVent)
        {
            controller.MoveSpeed = 2;
            controller.SprintSpeed = 3;
        }
        else if (isGrounded)
        {
            controller.MoveSpeed = 4;
            controller.SprintSpeed = 6;
        }
    }
}
