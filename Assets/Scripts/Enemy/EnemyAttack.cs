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
    private float FlickeringTimer = 0.1f;
    private bool SpriteDisabled = false;
    //public GameObject player = GameObject.FindGameObjectWithTag("Player");
    private SpriteRenderer spriteRenderer;
    private float EmergencyTimer = 2f;

    [SerializeField]
    Animator anim;

    //for triggering attack is stored in memory, not in gameobject(?)
    public static bool EnteredAttackZone = false;

    void Start()
    {
        //spriteRenderer = player.GetComponent<SpriteRenderer>();
        Invincible = false;
    }
    void Awake()
    {
        //anim = gameObject.GetComponent<Animator>();
        Hitbox.enabled = false;
    }

    private void Update()
    {
        /*
        if(spriteRenderer.enabled == false)
        {
            EmergencyTimer -= Time.deltaTime;
            if(EmergencyTimer <= 0)
            {
                spriteRenderer.enabled = true;
            }
        }
        */
        if (Invincible == true)
        {
           // SpriteFlickering();
            InvincibleTimer = InvincibleTimer - Time.deltaTime; //timer counts down
            if (InvincibleTimer <= 0) //stops when reaching 0
            {
                Invincible = false;
                InvincibleTimer = 2f;
                spriteRenderer.enabled = true;
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
    void SpriteFlickering()
    {
        spriteRenderer.enabled = false;
        SpriteDisabled = true;
        if (SpriteDisabled == true)
        {
            FlickeringTimer = FlickeringTimer - Time.deltaTime;
            if (FlickeringTimer <= 0)
            {
                spriteRenderer.enabled = true;
                FlickeringTimer = 0.1f;
            }
        }
    }
}
