using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public byte playerJumpForces = 5;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded;
    bool jump;
    [SerializeField] Animator anim;
    float lastYPos;
    public float distanceTraveled;
    [SerializeField] UIControler uiController;
    public int collectedCoins;
    [SerializeField] bool airJump = false;
    [SerializeField] bool shieldIsActive;
    [SerializeField] GameObject Shield;
    [SerializeField] SFXManager sfxManager;
    [SerializeField] bool playerIsFalling;


    Cameracontroler camController;
    private void Start()
    {
        lastYPos = transform.position.y;
    }

    void Update()
    {
        distanceTraveled += Time.deltaTime;
        CheckForInput();
        CheckIfPlayerIsFalling();
    }
    void FixedUpdate()
    {
        CheckForGround();
        CheckForJump();
    }

    void CheckForJump()
    {

        if (jump == true)
        {
            jump = false;
            
            rb.AddForce(new Vector2(0, playerJumpForces), ForceMode2D.Impulse);
        }
    }

    void CheckIfPlayerIsFalling()
    {
        if (transform.position.y < lastYPos)
        {
            anim.SetBool("Falling", true);
            playerIsFalling = true;
        }
        else
        {
            anim.SetBool("Falling", false);
            playerIsFalling = false;
        }

        lastYPos = transform.position.y;
    }

    void CheckForInput()
    {
        if (isGrounded == true || airJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (airJump == true && isGrounded == false) {
                    airJump = false;
                    sfxManager.PlaySFX("DoubleJump");
                }
                else
                {
                    sfxManager.PlaySFX("Jump");
                }
                jump = true;
                anim.SetTrigger("Jump");
            }
        }
    }

    void CheckForGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

        if (hit.collider != null) {

            if (hit.distance < 0.1f){
                isGrounded = true;
                anim.SetBool("IsGrounded", true);
                if (playerIsFalling == false)
                {
                    sfxManager.PlaySFX("Land");
                }
            }
            else
            {
                isGrounded = false;

            }
            //Debug.Log(hit.transform.name);
            Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green);
        }
        else
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", false);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Obsticle"))
        {
            if (shieldIsActive == true)
            {
                
                Shield.SetActive(false);
                shieldIsActive = false;
                sfxManager.PlaySFX("ShieldBreak");
                Destroy(collision.gameObject);
            }
            else {
                sfxManager.PlaySFX("GameOverHit");
                uiController.ShowGameOverScreen();
            }
            
        }
        if (collision.transform.CompareTag("DeathBox"))
        {
            uiController.ShowGameOverScreen();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable")) {
            collectedCoins++;
            sfxManager.PlaySFX("Coin");
            Destroy(collision.gameObject);



        }
        if (collision.CompareTag("airJump")) {
            airJump = true;
            sfxManager.PlaySFX("PowerupDoubleJump");
            Destroy(collision.gameObject);


        }

        if (collision.CompareTag("Shield")) {
            shieldIsActive = true;
            Shield.SetActive(true);
            sfxManager.PlaySFX("PowerupShield");
            Destroy(collision.gameObject) ;
            


        
        
        
        }




    }



}
