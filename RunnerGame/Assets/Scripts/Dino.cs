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

    public int highScoreCount;
    private float scoreCount = 0;
    private int trueScore;
    public Text score;
    public Text highScore;
    public GameObject scoreText;
    public GameObject gameOverText;
    public GameObject playAgainImage;
    public GameObject playAgainText;
    public GameObject soundOn;
    public GameObject soundOff;

    private int currentScene;

    AudioSource source;
    public AudioClip jumpSound;
    public AudioClip deadSound;
    public AudioClip scoreSound;
    public AudioClip bugScore;

    // Start is called before the first frame update
    void Start()
    {
        highScoreCount = PlayerPrefs.GetInt("highscore");
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentScene = SceneManager.GetActiveScene().buildIndex;

        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (!isDead)
        {
            CheckScore();
            CheckHighScore();
            DinoRun();

            if (Input.GetMouseButtonDown(0) && isGrouded)
            {
                DinoJump();
            }
        }

        if(isDead && Input.GetMouseButtonDown(0))
        {
            PlayAgain();
        }

    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(currentScene);
    }



    private void DinoRun()
    {
        transform.Translate(transform.right * 10 * Time.deltaTime);
    }

    private void DinoJump()
    {
        rb.velocity = new Vector2(0, 20);
        isGrouded = false;
        source.PlayOneShot(jumpSound, 1f);
    }

    private void DinoDied()
    {
        isDead = true;
        anim.SetTrigger("dead");
        gameOverText.SetActive(true);
        source.PlayOneShot(deadSound, 1f);
    }

    private void CheckScore()
    {
        scoreCount++;
        trueScore = ((int)(scoreCount / 15));
        score.text = trueScore.ToString();

        if( scoreCount % 1500 == 0)
        {
            source.PlayOneShot(scoreSound, 1f);
        }

        
    }
    private void CheckHighScore()
    {
        highScore.text = highScoreCount.ToString();
        if(trueScore > highScoreCount)
        {
            highScoreCount = trueScore;
            PlayerPrefs.SetInt("highscore", highScoreCount);
        }
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

        if(collision.gameObject.tag == "point")
        {
            scoreCount += 150;
            source.PlayOneShot(bugScore, 1f);
        }
    }
}

