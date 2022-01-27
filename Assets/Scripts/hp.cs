using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hp : MonoBehaviour
{

    public bool isClosed = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        isClosed = true;
        door(col);
    }
    public void door(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Destroy(gameObject);
            isClosed = true;
        }
    }
}
