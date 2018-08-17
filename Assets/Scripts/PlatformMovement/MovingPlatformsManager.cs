using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformsManager : MonoBehaviour {

    [SerializeField]
    List<PlatformMovement> movingPlatforms;

    public void UpdatePlatforms()
    {
        foreach (PlatformMovement p in movingPlatforms)
        {
            p.UpdateMovingPlatform();
        }
    }

}
