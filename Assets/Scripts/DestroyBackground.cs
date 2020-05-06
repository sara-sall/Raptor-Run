using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBackground : MonoBehaviour
{
    private float CameraXpos;

    // Update is called once per frame
    void Update()
    {

        CameraXpos = Camera.main.transform.position.x;
        if(CameraXpos > transform.position.x + 30)
        {
            Destroy(gameObject);
        }
    }
}
