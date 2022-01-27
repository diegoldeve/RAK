using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public Player p;
    public float moveSpeed = .5f;
    Rigidbody2D rb;
    public Transform player;
    private Vector2 movement;
    void Start()
    {
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
        

    }
    /*private void FixedUpdate()
    {
        if(p.score == 14)
        {
            Move(movement);
        }
        
    }*/
     void Move(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
