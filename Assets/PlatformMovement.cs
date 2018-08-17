using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour {

    [SerializeField]
    List<Vector3> borderPoints;
    [SerializeField]
    float timeBetweenBorderPoints;

    void Update()
    {
        this.gameObject.transform.position = borderPoints[0];

        for(float tempTime=0f;tempTime<=timeBetweenBorderPoints;tempTime+=Time.deltaTime)
        {
            this.gameObject.transform.position = Vector3.Lerp(borderPoints[0], borderPoints[1],  tempTime/timeBetweenBorderPoints);
            Debug.Log(this.transform.position);
            Debug.Log(tempTime / timeBetweenBorderPoints);
        }
    }
}
