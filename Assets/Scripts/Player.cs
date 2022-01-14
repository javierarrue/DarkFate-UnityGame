using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    //FIRE POINT
    public GameObject firePoint;

    //Vida del jugador
    public int maxHealth = 10;
    public int currentHealth;

    //Barra de vida
    public HealthBar healthBar;

    //Movimiento
    public CharacterController characterController;
    public float speed;
    public float jumpSpeed;
    private float directionY;
    float horizontalInput;

    //Ground Layer
    public LayerMask groundLayers;

    //Ground Checks
    public Transform[] groundChecks;

    //Gravedad
    public float gravity = -9.81f;

    Vector3 direction;

    //Animaciones
    Animator animator;

    int isRunningHash;
    int isRunningBackwardsHash;
    int isGrounded;
    int isDucking;

    bool grounded;

    void Start()
    {

        currentHealth = maxHealth;
        //Colocando el maximo de vida del enemigo
        healthBar.setMaxHealth(maxHealth);

        animator = GetComponent<Animator>();

        isRunningHash = Animator.StringToHash("isRunning");
        isRunningBackwardsHash = Animator.StringToHash("isRunningBack");
        isGrounded = Animator.StringToHash("isGrounded");

    }

    void Update()
    {
        //SI EL JUEGO NO ESTA PAUSADO
        if (!PauseMenu.gameIsPaused)
        {

            //Revisa si toca el suelo (true or false)
            //grounded = Physics.CheckSphere(transform.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore);

            grounded = false;
            foreach (var groundCheck in groundChecks)
            {
                if (Physics.CheckSphere(groundCheck.position, 0.1f, groundLayers, QueryTriggerInteraction.Ignore))
                {
                    grounded = true;
                    break;
                }
            }

            horizontalInput = Input.GetAxisRaw("Horizontal");

            move();

            //--------------------ANIMACIONES--------------------
            bool isRunning = animator.GetBool("isRunning");
            bool backPressed = Input.GetKey("a");
            bool forwardPressed = Input.GetKey("d");
            bool downPressed = Input.GetKey("s");

            //----------- CORRER ------------------
            //Activar animacion de CORRER
            if (backPressed | forwardPressed)
            {
                runForwardAnimation();
            }
            else
            {
                runAnimationOff();
            }
            //Rotar jugador
            if (backPressed)
            {
                rotatePlayerLeft();

            }
            else if (forwardPressed)
            {
                rotatePlayerRight();
            }

            //---------------AGACHARSE---------------
            if (grounded)
            {
                if (downPressed)
                {
                    animator.SetBool("isCrouching", true);
                    characterController.center = new Vector3(0, 0.7f, 0);
                    characterController.height = 1.2f;
                    firePoint.SetActive(false);
                }
                else
                {
                    animator.SetBool("isCrouching", false);
                    characterController.center = new Vector3(0, 1, 0);
                    characterController.height = 2f;
                    firePoint.SetActive(true);
                }

            }

            //------------- SALTAR -----------------
            //Seteando si el jugador esta en el suelo o no
            animator.SetBool(isGrounded, grounded);

            animator.SetFloat("VerticalSpeed", direction.y);

        }
    }

    private void move()
    {

        //Movimiento del jugador unicamente de forma horizontal
        direction = new Vector3(horizontalInput, 0f, 0f);

        //Si el jugador esta tocando el suelo:
        if (grounded)
        {
            //Resetear el valor en Y cada vez que toque el suelo.
            directionY = 0;
            jump();
        }

        //Estableciendo gravedad.
        directionY += gravity * Time.deltaTime;
        direction.y = directionY;

        //Movimiento del jugador.
        characterController.Move(direction * speed * Time.deltaTime);
    }


    private void jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            directionY = jumpSpeed;
            grounded = false;
        }
    }

    void runForwardAnimation()
    {
        animator.SetBool(isRunningHash, true);
    }

    void runAnimationOff()
    {
        animator.SetBool(isRunningHash, false);
    }


    void rotatePlayerRight()
    {
        transform.localScale = Vector3.one;

    }
    void rotatePlayerLeft()
    {
        transform.localScale = new Vector3(1, 1, -1);

    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        //Al recibir da�o, se actualiza la barra de vida.
        healthBar.setHealth(currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }

    }

    private void Die()
    {
        SceneManager.LoadScene("DeadScreen");
    }

    private void OnCollisionEnter(Collision collision)
    {
        /*if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        else */
        if (collision.gameObject.tag == "END")
        {
            Debug.Log("El fin");
            SceneManager.LoadScene("TheEnd");
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        //El layer 7 es para las vidas
        if (other.gameObject.layer == 7)
        {
            if (currentHealth < 9)
            {
                SoundManager.playSound("heal");
                currentHealth += 2;
                //Se actualiza la barra de vida.
                healthBar.setHealth(currentHealth);
                Destroy(other.gameObject);
            }
            else if (currentHealth == 9)
            {
                SoundManager.playSound("heal");
                currentHealth += 1;
                //Se actualiza la barra de vida.
                healthBar.setHealth(currentHealth);
                Destroy(other.gameObject);
            }

        }
    }
}
