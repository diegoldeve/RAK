using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thunder : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        Vector3 pos = transform.position;
        pos.x = Random.Range(28f, 80f);

        transform.position = pos;

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * 250);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 12)
        {
            Destroy(gameObject);
        }
    }
}
