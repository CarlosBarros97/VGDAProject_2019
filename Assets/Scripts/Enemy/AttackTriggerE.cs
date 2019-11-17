using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTriggerE : MonoBehaviour
{
    public HealthDrain PlayerHP;
    public EnemyAttack Hitting;
    private void OnTriggerEnter2D(Collider2D col)
    {
       if (!col.isTrigger && col.CompareTag("Player"))
        {
            if (Hitting.Invincible == false)
            {
                PlayerHP.HealthValue = PlayerHP.HealthValue - Hitting.LifeTake; //take damage
                Hitting.Invincible = true; //adds i-frames

                PlayerHP.HealthValue = PlayerHP.HealthValue - Hitting.LifeTake;
                Hitting.Invincible = true;
            }
        }
    }
}
