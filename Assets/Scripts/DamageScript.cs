using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    bool Invincible; //invincibility frames
    public float LifeTake = 20f;
    float InvincibleTimer = 2f;
    private float FlickeringTimer = 0.1f;
    private bool SpriteDisabled = false;
    public GameObject player = GameObject.FindGameObjectWithTag("Player");
    private SpriteRenderer spriteRenderer;

    public HealthDrain PlayerHP;
    void Start()
    {
        spriteRenderer = player.GetComponent<SpriteRenderer>();

        Invincible = false;
    }

    void Update()
    {
        if (Invincible == true)
        {
            //SpriteFlickering();
            InvincibleTimer = InvincibleTimer - Time.deltaTime; //timer counts down
            if (InvincibleTimer <= 0) //stops when reaching 0
            {
                Invincible = false;
                InvincibleTimer = 2f;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (Invincible == false)
        {
            PlayerHP.HealthValue = PlayerHP.HealthValue - LifeTake; //take damage
            Invincible = true; //adds i-frames
        }
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
