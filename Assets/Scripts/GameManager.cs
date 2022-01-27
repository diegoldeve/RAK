using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Text gravedad;
    public Text congrats;
    public Text congrats2;
    public GameObject key;
    public birdBoss boss;
    public GameObject door;
    public Text gameEnd;
    public hp hp2;
    public Image hpBar;
    public Text timerText;
    public float timeCount = 0;
    public GameObject thunder;
    public GameObject cristal;
    public GameObject cristall;
    public GameObject cristalll;    
    public GameObject penguin;
    public GameObject fire;
    Player player;
    public GameObject coin;
    public GameObject door1;
    public GameObject door2;
    public Text score;
    public int pts = 0;
    // Start is called before the first frame update
    void Start()
    {
        boss = FindObjectOfType<birdBoss>();
        hp2 = FindObjectOfType<hp>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        player = playerObj.GetComponent<Player>();
        StartCoroutine("cristalRoutine");
        StartCoroutine("cristalRoutine2");
        StartCoroutine("cristalRoutine3");
        StartCoroutine("thunderRoutine");
        StartCoroutine("thunderRoutine2");
        StartCoroutine("thunderRoutine3");
        StartCoroutine("thunderRoutine4");
        StartCoroutine("thunderRoutine5");
        StartCoroutine("thunderRoutine6");
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = player.hp / 100f;
        timeCount += Time.deltaTime;
        timerText.text = "" + (int)timeCount;

        firstDoor();
        keyy();
    }
    public void startGame()
    {

    }
    public void lose()
    {
        gameEnd.enabled = true;
        StartCoroutine("louseRoutine");
    }
    IEnumerator louseRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("Menu");
    }
    public void backMenu()
    {
    }
    public void firstDoor()
    {
        if (hp2.isClosed)
        {
            door1.SetActive(true);
        }
    }
    
    IEnumerator cristalRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            Instantiate(cristal);
        }
    }
    IEnumerator cristalRoutine2()
    {

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 2f));
            Instantiate(cristall);  
        }
    }
    IEnumerator cristalRoutine3()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 2.5f));
            Instantiate(cristalll);
        }
    }
    IEnumerator thunderRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f, 2.5f));
            Instantiate(thunder);
        }
    }
    IEnumerator thunderRoutine2()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 2.5f));
            Instantiate(thunder);
        }
    }
    IEnumerator thunderRoutine3()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f, 2.5f));
            Instantiate(thunder);
        }
    }
    IEnumerator thunderRoutine4()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1f,1.5f));
            Instantiate(thunder);
        }

    }
    IEnumerator thunderRoutine5()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(.5f, 1.5f));
            Instantiate(thunder);
        }
    }
    IEnumerator thunderRoutine6()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(.5f, 1.5f));
            Instantiate(thunder);
        }
    }
    IEnumerator loseRoutine()
    {

        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Menu");
    }
    public void secondDoor()
    {
        door2.SetActive(false);
    }
    public void keyy()
    {
        if (boss.isDie)
        {
            key.SetActive(true);
            StartCoroutine("gravity");
        }
    }
    public void congratss()
    {
        congrats.enabled = true;
        StartCoroutine("winRoutine");
        

    }
    IEnumerator winRoutine()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("Win");
        
    }
    IEnumerator gravity()
    {
        yield return new WaitForSeconds(5.0f);
        gravedad.enabled = true;
        yield return new WaitForSeconds(3.0F);
        gravedad.enabled = false;

    }


}
