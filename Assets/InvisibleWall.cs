using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleWall : MonoBehaviour {

    [SerializeField]
    Collider WallCollider;

	public void UpdateInvisibleWall(bool isPlayerGrounded)
    {
        if (Input.GetAxis("Jump") > 0)
            WallCollider.enabled = false;

        if (isPlayerGrounded)
            WallCollider.enabled = true;
    }

}
