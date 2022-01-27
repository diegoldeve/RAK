using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Penguin : MonoBehaviour
{
    public float health = 5;
    Rigidbody2D rb;
    public GameObject laser;
    
       void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("shoot");
        
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }
    IEnumerator shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            Instantiate(laser, transform.position, Quaternion.identity);
        }
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
            Destroy(gameObject);
        }
    }
}
