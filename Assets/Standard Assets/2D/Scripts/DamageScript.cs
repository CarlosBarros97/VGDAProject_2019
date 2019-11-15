﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    bool Invincible; //invincibility frames
    public float LifeTake = 20f;
    float InvincibleTimer = 2f;
    void Start()
    {
     Invincible = false;
    }

    void Update()
    {
        if(Invincible == true)
        {
            InvincibleTimer = InvincibleTimer - Time.deltaTime; //timer counts down
            if(InvincibleTimer <= 0) //stops when reaching 0
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
            HealthDrain.HealthValue = HealthDrain.HealthValue - LifeTake; //take damage
            Invincible = true; //adds i-frames

        }
    }
}
