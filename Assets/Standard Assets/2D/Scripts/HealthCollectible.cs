using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{ public float LifeAdd = 20f; 
    void OnTriggerEnter2D(Collider2D collision) //collider touches collectible 
    {
     HealthDrain.HealthValue = HealthDrain.HealthValue + LifeAdd; //HealthDrain.HealthValue += LifeAdd;
     Destroy(gameObject);
    }
}
