using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    float movementForce;
    [SerializeField]
    float jumpForce;
    [SerializeField]
    Rigidbody playerRigidbody;

    
    public void UpdatePlayerMovement(Transform cameraTransform) // (MovementStyle)
    {
       
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float jmp = 0;
        if (Input.GetKeyDown(KeyCode.Space))
            jmp = jumpForce;

        Debug.Log(cameraTransform.forward.ToString() + " "+ cameraTransform.right.ToString() + " " + cameraTransform.up.ToString());

        playerRigidbody.AddForce(new Vector3(cameraTransform.forward.x, 0f, cameraTransform.forward.z) * ver * movementForce);
        playerRigidbody.AddForce(cameraTransform.right * hor * movementForce);
        playerRigidbody.AddForce(new Vector3(0f,cameraTransform.up.y,0f) * jmp);
        
    }
}
