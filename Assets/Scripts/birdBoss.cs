using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdBoss : MonoBehaviour
{
    public bool isDie = false;
    public int health = 40;
    public hp hp2;
    public GameManager gm;
    public Player p;
    public float moveSpeed = 3f;
    Rigidbody2D rb;
    public Transform player;
    private Vector2 movement;
    void Start()
    {
        hp2 = FindObjectOfType<hp>();
        gm = FindObjectOfType<GameManager>();
        p = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = player.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        dir.Normalize();
        movement = dir;
        Die();


    }
    private void FixedUpdate()
    {
        if (hp2.isClosed)
        {
            Move(movement);
        }

    }
    void Move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "laser")
        {
            health--;
        }
    }
    public void Die()
    {
        if (health <= 0)
        {
            isDie = true;
            Destroy(gameObject);
        }
    }
}
