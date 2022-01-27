using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mr : MonoBehaviour
{
    GameManager gc;
    void Start()
    {
        gc = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            gc.congratss();
        }
    }
}
