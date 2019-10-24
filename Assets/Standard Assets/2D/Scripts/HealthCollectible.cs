using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{ public float LifeAdd = 20f;
    void OnTriggerEnter2D(Collider2D collision)
    {
     HealthDrain.HealthValue = HealthDrain.HealthValue + LifeAdd;
     Destroy(gameObject);
    }
}
