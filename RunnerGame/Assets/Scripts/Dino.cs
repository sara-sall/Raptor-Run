using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Dino : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool isGrouded = true;
    private Animator anim;
    public bool isDead = false;

    private float scoreCount = 0;
    public Text score;
    public GameObject scoreText;
    public GameObject gameOverText;

    private int currentScene;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentScene = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!isDead)
        {
            CheckScore();
            DinoRun();

            if (Input.GetMouseButtonDown(0) && isGrouded)
            {
                DinoJump();
            }
        }

        if(isDead && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(currentScene);
        }

    }

    private void DinoRun()
    {
        transform.Translate(transform.right * 10 * Time.deltaTime);
    }

    private void DinoJump()
    {
        rb.velocity = new Vector2(0, 20);
        isGrouded = false;
    }

    private void DinoDied()
    {
        isDead = true;
        anim.SetTrigger("dead");
        gameOverText.SetActive(true);
    }

    private void CheckScore()
    {
        scoreCount++;
        score.text = ((int)(scoreCount/15)).ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "background")
        {
            isGrouded = true;
        }

        if (collision.gameObject.tag == "obstacle")
        {
            DinoDied();
        }
    }
}

