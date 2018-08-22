using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour, iPlayer {

   
    [SerializeField]
    private Player Player;
    public Player player { get { return Player; } }
    [SerializeField]
    private CameraController CameraController;
    public CameraController cameraController { get { return CameraController; } }
    [SerializeField]
    private UIController UIController;
    public UIController uiController { get { return UIController; } }
    [SerializeField]
    private MovingPlatformsManager MovingPlatformsManager;
    public MovingPlatformsManager movingPlatformsManager { get { return MovingPlatformsManager; } }
    [SerializeField]
    private InvisibleWallsManager InvisibleWallsManager;
    public InvisibleWallsManager invisibleWallsManager { get { return invisibleWallsManager;  } }

    void Start () {
        Player.listener = this;
	}
	
	void Update () {
        MovingPlatformsManager.UpdatePlatforms();
        Player.UpdatePlayer();
        CameraController.UpdateCameraInput();
        InvisibleWallsManager.UpdateAllWalls(player.isGrounded);
	}

    void FixedUpdate()
    {
        Player.UpdatePlayerPhysics();
    }

    void LateUpdate()
    {
        CameraController.LateUpdateCameraTransform(player.gameObject.transform);
    }

    public void PlayerStateChanged(string playerState)
    {
        UIController.gameView.SetPlayerStateText(playerState);
    }
}
