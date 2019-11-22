using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool attacking = false;
    private float animTimer = 1.5f;
    private float attackTimer = 0f;
    [SerializeField]
    private float attackCD = .5f;

    public Collider2D attackTrigger;

    //can remove comments if we get an attack animation
    private Animator anim;

    void Awake()
    {
        anim = gameObject.GetComponent<Animator>();
        attackTrigger.enabled = false;
    }
    private void setParam()
    {
        //b = false;
        anim.SetBool("Attacking", false);
    }
    private void Update()
    {
        if((Input.GetKeyDown("z") || Input.GetKeyDown("k")) && !attacking)
        {
            attacking = true;
            attackTimer = attackCD;
            attackTrigger.enabled = true;
            anim.SetBool("Attacking", true);
        }

        if (attacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
                animTimer -= Time.deltaTime;
                
            }
            else
            {
                attacking = false;
                attackTrigger.enabled = false;
                Invoke("setParam", .5f);
            }
            
        }

        
        

        //remove if attack animation gets implimented
    }
}
