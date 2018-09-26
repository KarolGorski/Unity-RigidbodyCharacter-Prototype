using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour {

    [SerializeField]
    GameObject bulletPrefab;
    [SerializeField]
    float bulletSpeed = 50f;
    [SerializeField]
    float shootFrequency = 0.2f;
    float timeTemp = 0f;

    public void Shoot(Player player)
    {
        timeTemp += Time.deltaTime;
        if (Input.GetAxis("Fire1") > 0)
        {
            player.ChangePlayerState(Keys.PlayerStates.SHOOTING);
            if (timeTemp >= shootFrequency)
            {
                GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.forward * (transform.localScale.z), Quaternion.Euler(90f, transform.eulerAngles.y, 0));
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.VelocityChange);
                timeTemp = 0f;

            }
        }
            
    }
}
