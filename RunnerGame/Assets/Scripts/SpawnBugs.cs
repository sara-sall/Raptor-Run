using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBugs : MonoBehaviour
{
    public GameObject[] bugsArray;
    private GameObject bug;
    private float XPos;
    private int number;

    private float randomPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1.5f, 2f);
        //Start method Spawn in 1.5s, repeat every 2s
    }

    private void Spawn()
    {
        if (!GameObject.Find("Dino").GetComponent<Dino>().isDead)
        {
            number = Random.Range(0, 8);
            randomPosition = Random.Range(21, 31);
            XPos = transform.position.x + randomPosition;
            bug = bugsArray[number] as GameObject;

            Instantiate(bug, new Vector2(XPos, bug.transform.position.y), Quaternion.identity);
        }
    }
}
