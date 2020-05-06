using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{

    public GameObject[] obstacles;
    private GameObject obj;
    private float XPos;
    private int number;

    private float randomPosition;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 1.5f, 1.6f);
        //Start method Spawn in 1.5s, repeat every 1.6s
    }

    private void Spawn()
    {
        if (!GameObject.Find("Dino").GetComponent<Dino>().isDead)
        {
            number = Random.Range(0, 7);
            randomPosition = Random.Range(21, 31);
            XPos = transform.position.x + randomPosition;
            obj = obstacles[number] as GameObject;

            Instantiate(obj, new Vector2(XPos, obj.transform.position.y), Quaternion.identity);
        }
    }
}
