using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChecker : MonoBehaviour
{
    Rigidbody2D rb;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x != 0)
        {
            anim.SetBool("isMoving", true);
        }

        if (rb.velocity.x == 0)
        {
            anim.SetBool("isMoving", false);
        }

        if (rb.velocity.y == 0)
        {
            anim.SetBool("Grounded", true);
        }

        if (rb.velocity.y != 0)
        {
            anim.SetBool("Grounded", false);
        }

        if (rb.velocity.y > 0)
        {
            anim.SetBool("isJumping", true);
        }

        if (rb.velocity.y <= 0)
        {
            anim.SetBool("isJumping", false);
        }

        if (rb.velocity.y < 0)
        {
            anim.SetBool("Land", true);
        }

        if (rb.velocity.y >= 0)
        {
            anim.SetBool("Land", false);
        }
    }
}
