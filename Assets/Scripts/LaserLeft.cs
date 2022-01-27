using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserLeft : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * 400);
        StartCoroutine("laserDie");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator laserDie()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f);
            Destroy(gameObject);
        }
    }
}
