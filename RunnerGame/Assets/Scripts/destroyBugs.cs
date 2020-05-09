using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyBugs : MonoBehaviour
{

    private GameObject bug;

    void Start()
    {
        bug = GameObject.FindWithTag("point");
    }

    // Update is called once per frame
    void Update()
    {
        bug = GameObject.FindWithTag("point");

        if (transform.position.x > bug.transform.position.x + 5)
        {
            Destroy(bug);
        }
    }
}
