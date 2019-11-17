using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private bool attacking = false;

    private float attackTimer = 0f;
    [SerializeField]
    private float attackCD = .3f;

    public Collider2D Hitbox;
    public Collider2D TriggerZone;
    //can remove comments if we get an attack animation
    //private Animator anim;

    public bool Invincible; //invincibility frames
    public float LifeTake = 20f;
    float InvincibleTimer = 2f;

    [SerializeField]
    Animator anim;

    //for triggering attack is stored in memory, not in gameobject(?)
    public static bool EnteredAttackZone = false;

    void Start()
    {
        Invincible = false;
    }
    void Awake()
    {
        //anim = gameObject.GetComponent<Animator>();
        Hitbox.enabled = false;
    }

    private void Update()
    {
        if (Invincible == true)
        {
            InvincibleTimer = InvincibleTimer - Time.deltaTime; //timer counts down
            if (InvincibleTimer <= 0) //stops when reaching 0
            {
                Invincible = false;
                InvincibleTimer = 2f;
            }
        }

       if (EnteredAttackZone && !attacking)
        {
            attacking = true;
            attackTimer = attackCD;
            Hitbox.enabled = true;
            anim.SetTrigger("AttackTrigger");
        }
        
        if (attacking)
        {
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                Hitbox.enabled = false;
                EnteredAttackZone = false;
            }
        }
        //remove if attack animation gets implimented
        // anim.SetBool("Attacking", attacking);
    }
}
