using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    [SerializeField]
    float distance;

    float currentX=0f, currentY=0f;
    float yMinAngle = -50f;
    float yMaxAngle = 0f;
    
	public void UpdateCameraInput()
    {
        currentX += Input.GetAxis("Mouse X");
        currentY -= Input.GetAxis("Mouse Y");
        currentY = Mathf.Clamp(currentY, yMinAngle, yMaxAngle);
    }

    public void LateUpdateCameraTransform(Transform playerTransform)
    {
        Vector3 direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        this.gameObject.transform.position = playerTransform.position + rotation * direction;
        this.gameObject.transform.LookAt(playerTransform);
    }
}
