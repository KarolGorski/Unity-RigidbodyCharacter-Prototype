using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private MovingPlatformsManager MovingPlatformsManager;
    public MovingPlatformsManager movingPlatformsManager { get { return MovingPlatformsManager; } }
    [SerializeField]
    private Player Player;
    private Player player { get { return Player; } }
    [SerializeField]
    private CameraController CameraController;
    private CameraController cameraController { get { return CameraController; } }

    void Start () {
		
	}
	
	void Update () {
        MovingPlatformsManager.UpdatePlatforms();
        Player.UpdatePlayerMovement();
        CameraController.UpdateCameraInput();
	}

    private void LateUpdate()
    {
        CameraController.LateUpdateCameraTransform(player.gameObject.transform);
    }
}
