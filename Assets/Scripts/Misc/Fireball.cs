using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    // Fireball Velocity
    [SerializeField] private float _speed = 15f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        if(transform.position.y > 17f || transform.position.y < 17f)
        {
            Destroy(this.gameObject);
        }
    }
}
