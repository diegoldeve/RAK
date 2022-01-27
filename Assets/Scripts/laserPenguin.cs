using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserPenguin : MonoBehaviour
{
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(-550, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x <30)
        {
            Destroy(gameObject);
        }
    }
}
