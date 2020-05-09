using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DinoStart : MonoBehaviour
{

    public GameObject playImage;
    public GameObject playText;
    public GameObject soundOn;
    public GameObject soundOff;
    public int highScoreCount;
    public Text highScore;

    // Start is called before the first frame update
    void Start()
    {
        highScoreCount = PlayerPrefs.GetInt("highscore");
        highScore.text = highScoreCount.ToString();

    }

    private void Update()
    {
       // if (Input.GetMouseButtonDown(0))
        {
            //SceneManager.LoadScene("main");
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
        Debug.Log("Click");
    }
}
