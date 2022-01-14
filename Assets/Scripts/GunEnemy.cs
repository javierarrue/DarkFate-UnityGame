using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : MonoBehaviour
{
    //Proyectil de enemigo
    public Transform firePoint;
    public GameObject bulletPrefab;

    //Time para disparar
    float timer;
    public float waitingTime = 1f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > waitingTime)
        {
            SoundEnemys.playSound("turretShot");
            shoot();
            timer = 0;
        }
    }

    private void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
