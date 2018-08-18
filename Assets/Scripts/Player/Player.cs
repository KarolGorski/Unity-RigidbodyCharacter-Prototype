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

    public void UpdatePlayerMovement()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float jmp = 0;
        if (Input.GetKeyDown(KeyCode.Space))
            jmp = jumpForce;
        playerRigidbody.AddForce(-new Vector3(hor, -jmp, ver)*movementForce);
    }
}
