using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public int damage = 2;


    // Start is called before the first frame update
    void Start()
    {

        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.takeDamage(damage);
            SoundEnemys.playSound("hit");
        }

        if (other.gameObject.layer != 8)
        {
            Destroy(gameObject);
        }
        //Cuando el proyectil haga impacto con algo, este seria destruido

    }

}
