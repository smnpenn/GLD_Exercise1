using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;
    public Transform playerPosition;
    public float cameraYOffset;
    public LayerMask ventMask;
    public LayerMask groundMask;

    // Update is called once per frame
    void Update()
    {
        //transform.position = cameraPosition.position;

        if(Physics.Raycast(playerPosition.position, Vector3.down, 2 * 0.5f + 0.2f, ventMask))
        {
            cameraPosition.position = new Vector3(playerPosition.position.x, playerPosition.position.y + 0.4f, playerPosition.position.z);
        }
        else if(Physics.Raycast(playerPosition.position, Vector3.down, 2 * 0.5f + 0.2f, groundMask))
        {
            cameraPosition.position = new Vector3(playerPosition.position.x, playerPosition.position.y + cameraYOffset, playerPosition.position.z);
        }
    }
}
