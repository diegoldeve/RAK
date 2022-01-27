using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    public float health = 3;
    public float minX, maxX;
    public float wait = 2f;
    public float vel = 1f;
    private GameObject target;
    void Start()
    {
        UpdateObj();
        StartCoroutine("Patrullar");
    }

    // Update is called once per frame
    void Update()
    {
        Die();
    }
    private void UpdateObj()
    {
        if(target == null)
        {
            target = new GameObject("Sitio");
            target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
            return;
        }
        if (target.transform.position.x == minX)
        {
            target.transform.position = new Vector2(maxX, transform.position.y);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(target.transform.position.x == maxX)
        {
            target.transform.position = new Vector2(minX, transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);

        }
    }

    IEnumerator Patrullar()
    {
        while (Vector2.Distance(transform.position, target.transform.position) > 0.05f)
        {
            Vector2 direc = target.transform.position - transform.position;
            float DirecX = direc.x;
            transform.Translate(direc.normalized * vel * Time.deltaTime);
            yield return null;
        }
        transform.position = new Vector2(target.transform.position.x, transform.position.y);
        yield return new WaitForSeconds(wait);
        UpdateObj();
        StartCoroutine("Patrullar");

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "laser")
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
