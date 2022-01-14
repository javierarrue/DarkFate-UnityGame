using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    public Transform firePoint;
    public GameObject bulletPrefab;

    //Restriccion para disparar
    float timer;
    public float waitingTime = 1f;

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitingTime)
        {
            if (Input.GetButtonDown("Fire1")) //el boton de disparar es j
            {

                shoot();
                SoundManager.playSound("fireSound");
                timer = 0;
            }
        }
    }

    private void shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
