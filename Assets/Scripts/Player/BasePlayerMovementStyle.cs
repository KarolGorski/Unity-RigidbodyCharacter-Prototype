using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerMovementStyle{
    float movementVelocity = 0.8f;
    float jumpVelocity = 3f;
    Vector3 inputVector;

    bool isSprinting = false;

    public virtual void ExecuteMovement(Player player)
    {
        GetInput();
        ChangeMovementStyle(player);

        if (inputVector.Equals(Vector3.zero)) return;
        RotatePlayer(player);
        MovePlayer(player);
    }

    protected virtual void GetInput()
    {
        inputVector = new Vector3(
            Input.GetAxis("Horizontal"), 
            Input.GetAxis("Jump"), 
            Input.GetAxis("Vertical"));
        isSprinting = Input.GetAxis("Sprint") > 0;
    }

    protected virtual void ChangeMovementStyle(Player player)
    {   
        // Here to implement swaping to another ways of movement for player. Just inherit from this class and override some things :)
        //if (triggerOnOtherMovementStyle)
        //    player.ChangeMovementStyle(new anotherPlayerMovementStyle());
    
    }

    protected virtual void RotatePlayer(Player player)
    {
        float angle = Mathf.Atan2(inputVector.x, inputVector.z);
        angle = Mathf.Rad2Deg * angle;
        angle += Camera.main.transform.eulerAngles.y;

        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        player.transform.rotation = Quaternion.Slerp(player.transform.rotation, targetRotation, 5f * Time.deltaTime);
    }

    protected virtual void MovePlayer(Player player)
    {
        Jump(player);
        Move(player);
    }

    protected virtual void Jump(Player player)
    {
        if (inputVector.y.Equals(0))
            return;
        if (!player.isGrounded)
            return;
        Vector3 temp = player.transform.up * jumpVelocity;
        if (player.isBuffed)
            temp *= 1.5f;
        player.playerRigidbody.AddForce(temp, ForceMode.VelocityChange);
        player.ChangePlayerState(Keys.PlayerStates.IN_AIR);
  
    }

    protected virtual void Move(Player player)
    {
        if (inputVector.x.Equals(0) && inputVector.z.Equals(0))
            return;
        Vector3 temp = Vector3.zero;
        temp += player.forwardDirection * movementVelocity;
        if (isSprinting)
        {
            temp *= 1.5f;
            player.ChangePlayerState(Keys.PlayerStates.RUNNING);
        }
        else
            player.ChangePlayerState(Keys.PlayerStates.MOVING);
        if (player.isBuffed)
        {
            temp *= 1.5f;
            player.ChangePlayerState(Keys.PlayerStates.BUFFED);
        }    
        player.playerRigidbody.AddForce(temp, ForceMode.VelocityChange); 

    }
}
