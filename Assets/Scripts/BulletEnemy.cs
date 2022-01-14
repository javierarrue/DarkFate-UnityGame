using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public int damage = 1;

    public float lifetime = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void Update()
    {
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        Bullet bullet = other.GetComponent<Bullet>();


        if (player != null)
        {
            player.takeDamage(damage);
        }

        //Si el proyectil choca con una bala del jugador, la ignora.
        if (bullet == null)
        {
            //Cuando el proyectil haga impacto con algo, este seria destruido
            Destroy(gameObject);
        }

    }
}
