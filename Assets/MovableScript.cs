using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableScript : MonoBehaviour {
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name.Equals("Player") && collision.gameObject.transform.position.y > transform.position.y)
            GetComponent<Rigidbody>().AddForce(collision.transform.forward * 10, ForceMode.Impulse);
    }
}
