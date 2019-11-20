using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public float LifeAdd = 20f;
    //collider touches collectible 
    private bool movingUp = true;
    public float changeTimer = .5f;
    public float speed = 1f;

    public HealthDrain PlayerHP;

    
    void Update()
    {
        transform.Translate(((movingUp) ? Vector2.up : Vector2.down) * speed * Time.deltaTime);
        if (movingUp)
        {
            changeTimer = changeTimer - Time.deltaTime;
            if (changeTimer <= 0)
            {
                movingUp = false;
                changeTimer = .3f;
            }
        }
        if (!movingUp)
        {
            changeTimer = changeTimer - Time.deltaTime;
            if (changeTimer <= 0)
            {
                movingUp = true;
                changeTimer = .3f;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entered pudding");
        PlayerHP.HealthValue = PlayerHP.HealthValue + LifeAdd; //PlayerHP.HealthValue += LifeAdd;
        Destroy(gameObject);
    }
}
