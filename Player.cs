using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    private Rigidbody2D rig;
    private Animator anim;
    public float JumpForce;
    public bool isJumping;
    private bool isAlive = true;
    private bool hasCollided;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Enemy.defeatedByEnemy = false;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move() {
        
        if(isAlive && Enemy.defeatedByEnemy == false) {
            float movement = Input.GetAxis("Horizontal");            
            rig.velocity = new Vector2(movement * Speed, rig.velocity.y);
            if(movement > 0f) {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
                anim.SetBool("walk", true);
            }
            if(movement < 0f) {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
                anim.SetBool("walk", true);
            }
            if(movement == 0f) {
                anim.SetBool("walk", false);
            }
        }

    }

    void Jump() {

        if(isAlive) {
            if(Input.GetButtonDown("Jump") && !isJumping) {            
                anim.SetBool("jump", true);
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        
        if(collision.gameObject.layer == 8) {
            isJumping = false;
            anim.SetBool("jump", false);
        }
        if((collision.gameObject.tag == "Spike_Tag" || collision.gameObject.tag == "Fire_Tag" 
        || collision.gameObject.tag == "SawLevel1_Tag" || collision.gameObject.tag == "SpikeHead_Tag") && !hasCollided) {
            hasCollided = true;
            isAlive = false;            
            anim.SetBool("die", true);            
            Invoke("UpdateLives", 0.5f);
        }
        if(collision.gameObject.tag == "PlatformRL_Tag") {
             transform.parent = collision.transform;
        }

    }

    void OnCollisionExit2D(Collision2D collision) {
        if(collision.gameObject.layer == 8) {
            isJumping = true;
        }
        if(collision.gameObject.tag == "PlatformRL_Tag") {
            transform.parent = null;                 
        }
    }   

    void UpdateLives() {
        GameController.instance.UpdateLives();
    }

}