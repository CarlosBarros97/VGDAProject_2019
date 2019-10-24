using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    bool Invincible;
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
            InvincibleTimer = InvincibleTimer - Time.deltaTime;
            if(InvincibleTimer <= 0)
            {
             Invincible = false;
            }
        }
    }

     void OnCollisionEnter2D(Collision2D collision)
    {
        if (Invincible == false)
        {
            HealthDrain.HealthValue = HealthDrain.HealthValue - LifeTake;
            Invincible = true;

        }
    }
}
