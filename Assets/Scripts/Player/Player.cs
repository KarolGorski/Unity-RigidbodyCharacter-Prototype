using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public iPlayer listener;
    [SerializeField]
    private Rigidbody PlayerRigidbody;
    public Rigidbody playerRigidbody { get { return PlayerRigidbody; } }
    [SerializeField]
    private Collider PlayerCollider;
    public Collider playerCollider { get { return PlayerCollider; } }
    [SerializeField]
    LayerMask maskToRaycast;
    private RaycastHit downHitInfo;
    public Vector3 forwardDirection { get; private set; }
    public string playerState { get; private set; }
    public bool isGrounded { get; private set; }
    public bool isOnBorder { get; private set; }
    public bool isBuffed { get; private set; }
    [SerializeField]
    ParticleSystem playerBuffedParticle;
    [SerializeField]
    ShootingSystem shootingSystem;
    BasePlayerMovementStyle movementStyle;

    private void Start()
    {
        movementStyle = new BasePlayerMovementStyle();
    }

    public void UpdatePlayer()
    {
        CheckIfGrounded();
        CheckGroundInFrontOfPlayer();
        CalculateForwardDirection();  
    }

    public void UpdatePlayerPhysics()
    {
        
        movementStyle.ExecuteMovement(this);
        shootingSystem.Shoot(this);
    }

    public void ChangeMovementStyle(BasePlayerMovementStyle newStyle)
    {
        movementStyle = newStyle;
    }

    public void ChangePlayerState(string playerState)
    {
        if ((playerState.Equals(Keys.PlayerStates.RUNNING) ||
            playerState.Equals(Keys.PlayerStates.MOVING)) &&
            this.playerState.Equals(Keys.PlayerStates.IN_AIR) &&
            playerRigidbody.velocity.y<0)
            return;
        this.playerState = playerState;
        listener.PlayerStateChanged(this.playerState);
    }

    void CalculateForwardDirection()
    {
        forwardDirection = Vector3.Cross(transform.right, downHitInfo.normal);
    }

    void CheckIfGrounded()
    {
        Vector3 rayStart = transform.position;
        //Debug.DrawRay(rayStart, Vector3.down * playerCollider.bounds.size.y, Color.red, 2f);

        isGrounded = Physics.Raycast(rayStart, Vector3.down, playerCollider.bounds.size.y, maskToRaycast);
        if(isGrounded && playerRigidbody.velocity.Equals(Vector3.zero))
            ChangePlayerState(Keys.PlayerStates.STANDING);
        if (!isGrounded && playerRigidbody.velocity.y < 0)
            ChangePlayerState(Keys.PlayerStates.IN_AIR);
    }

    void CheckGroundInFrontOfPlayer()
    {
        Vector3 rayStart = transform.position + transform.forward * playerCollider.bounds.size.z;
        //Debug.DrawRay(rayStart, Vector3.down* playerCollider.bounds.size.y*1.5f, Color.green, 5f);
        isOnBorder = !Physics.Raycast(rayStart, Vector3.down, out downHitInfo, playerCollider.bounds.size.y*1.5f, maskToRaycast) && isGrounded;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (isBuffed) return;
        if (other.gameObject.name.Contains("Buff"))
            StartCoroutine(BuffTriggered());
    }

    IEnumerator BuffTriggered()
    {
        isBuffed = true;
        playerBuffedParticle.Play();
        yield return new WaitForSeconds(4f);
        playerBuffedParticle.Stop();
        isBuffed = false;

    }

}
