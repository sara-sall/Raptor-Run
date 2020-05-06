using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{

    private Rigidbody2D rb;
    private bool isGrouded = true;
    private Animator anim;
    public bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isDead)
        {
           DinoRun();

            if (Input.GetMouseButtonDown(0) && isGrouded)
            {
                DinoJump();
            }
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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "background")
        {
            isGrouded = true;
        }

        if (collision.gameObject.tag == "obstacle")
        {
            DinoDied();
        }
    }
}
