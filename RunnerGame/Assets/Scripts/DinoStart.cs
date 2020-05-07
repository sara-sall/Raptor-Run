using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinoStart : MonoBehaviour
{

    public GameObject playImage;
    public GameObject playText;
    public GameObject soundOn;
    public GameObject soundOff;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("main");
        }
    }
}
