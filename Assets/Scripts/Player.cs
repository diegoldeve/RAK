using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public GameObject laserLeft;
    public GameObject laser;
    public GameManager gc;
    Rigidbody2D rb;
    Animator anim;
    SpriteRenderer sr;
    private float jumpForce = 350f;
    public int speed = 25;
    private float time = 1;
    public float hp = 100;
    public float h;
    private bool grounded;
    public Text txScore;
    public int score;

    void Start()
    {
        gc = FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
       
    }

    void Update()
    {

        txScore.text = "Coins: " + score;

        Move();
        jump();
        pause();
        noPause();
        lose();
        Shoot();
        Premium();
    }
    public void jump()
    {
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            grounded = false;
            rb.AddForce(Vector2.up*jumpForce);
            anim.Play("jump");
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "grass")
        {
            grounded = true;
        }
        if (col.transform.tag == "beak")
        {
            hp -= 5;
            StartCoroutine("color");
        }
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "timeneg")
        {
           // Time.timeScale = time * 0.5f;
        }
        if (col.tag == "coin")
        {
            score++;
        }
        if (col.tag == "inv")
        {
            
            rb.gravityScale *=- 1;
            rb.rotation = 180;
        }
        if (col.tag == "runbad")
        {
            
        }
        if (col.tag == "fire")
        {
            hp -= 6;
            StartCoroutine("color");
        }
        if (col.tag == "snake")
        {
            hp-=5;
            StartCoroutine("color");
        }
        if (col.tag == "cristal" || col.tag=="thunder")
        {
            hp -= 3f;
            StartCoroutine("color");
        }
        if (col.tag == "bird")
        {
            //hp -= 15;
        }
        if (col.tag == "timepos")
        {
            gc.timeCount -= 30;
        }
        if (col.tag == "hp")
        {
            hp += 30;
        }
        if (col.tag == "die")
        {
            gc.lose();
        }

    }
    public void pause()
    {
        if (Input.GetKey(KeyCode.M))
        {
            Time.timeScale = time * 0;
        }
    }
    public void noPause()
    {
        if (Input.GetKey(KeyCode.N))
        {
            Time.timeScale = time;
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "zone")
        {
           
            rb.mass = 2;

            rb.gravityScale = -1;
            

        }
        if (col.tag == "run")
        {
            speed += 5;

        }
        if (col.tag == "runbad")
        {
            speed -= 5;
        }
        if (col.tag == "sand")
        {
            speed = -25;
            
        }
        if (col.tag == "bird")
        {
            hp -= 0.05f;
            StartCoroutine("color");
        }
        if (col.tag == "boss")
        {
            hp -= 0.09f;
            StartCoroutine("color");

        }

    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "zone")
        {
            rb.mass = 1;
            rb.gravityScale = 1;
            
        }
        if (other.tag == "inv")
        {
            rb.rotation = 0;
        }
        if (other.tag == "run")
        {
            speed = 25;
        }
        if (other.tag == "runbad")
        {
            speed *= (int)-1.5;

        }
        if (other.tag == "sand")
        {
            speed = 25;
        }

    }
    public void Inverted()
    {
        
        Vector3 rbVel = rb.velocity;
        if (rbVel.x < -0)
        {
            rbVel.x = 5;
        }
        if (rbVel.x > 0)
        {
            rbVel.x = -5;
        }
        if (h == 0)
        {
            rbVel.x = 0;
        }
        rb.velocity = rbVel;
    }
    public void Move()
    {
        h = Input.GetAxisRaw("Horizontal");


        if (h > 0)
        {
            anim.Play("run");
            sr.flipX = false;
        }
        else if (h < 0)
        {
            anim.Play("run");
            sr.flipX = true;
        }
        else
        {
            anim.Play("start");
        }
        rb.AddForce(new Vector2(h * speed, 0));
        Vector3 rbVel = rb.velocity;
        if (rbVel.x < -0)
        {
            rbVel.x = -5;
        }
        if (rbVel.x > 0)
        {
            rbVel.x = 5;
        }
        if (h == 0)
        {
            rbVel.x = 0;
        }
        rb.velocity = rbVel;
    }
    public void lose()
    {
        if (hp<=0)
        {
            gc.lose();
        }
    }
    public void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.P) && !sr.flipX)
        {
            Instantiate(laser, transform.position, Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.O) && sr.flipX)
        {
            Instantiate(laserLeft, transform.position, Quaternion.identity);
        }
    }
    public void Premium()
    {
        if (score == 1)
        {
            gc.door.SetActive(false);
        }
    }
    IEnumerator color()
    {
        sr.color = new Color(58/255, 164/255, 48/255, 1);
        yield return new WaitForSeconds(1.0f);
        sr.color = new Color(1, 1, 1, 1);
    }
}
