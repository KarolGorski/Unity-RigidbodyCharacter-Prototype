using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private MovingPlatformsManager MovingPlatformsManager;
    public MovingPlatformsManager movingPlatformsManager { get { return MovingPlatformsManager; } }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        movingPlatformsManager.UpdatePlatforms();
	}
}
