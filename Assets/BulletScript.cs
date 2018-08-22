using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public Rigidbody bulletRigidbody;
    float timeToLive = 5f;

    private void Start()
    {
        StartCoroutine(LifeCountdown());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.name.Contains("Bullet"))
            bulletRigidbody.useGravity = true;
    }

    IEnumerator LifeCountdown()
    {
        yield return new WaitForSeconds(timeToLive);
        Destroy(this.gameObject);
        yield return null;
    }
}
