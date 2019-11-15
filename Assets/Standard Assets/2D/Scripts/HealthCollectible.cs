using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
<<<<<<< HEAD
{ public float LifeAdd = 20f; 
    void OnTriggerEnter2D(Collider2D collision) //collider touches collectible 
=======
{   public float LifeAdd = 20f;
    private bool movingUp = true;
    public float changeTimer = .5f;
    public float speed = 1f;
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
>>>>>>> 7566ba911d1fcddbf0c63e87ca09c30022deedfb
    {
     HealthDrain.HealthValue = HealthDrain.HealthValue + LifeAdd; //HealthDrain.HealthValue += LifeAdd;
     Destroy(gameObject);
    }
}
