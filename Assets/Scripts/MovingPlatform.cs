using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private bool movingRight = true;
    private float DirectionTimer = 2.8f;
    private float changeTimer;
    public float speed = 2f;

    private void Start()
    {
        changeTimer = DirectionTimer;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(((movingRight) ? Vector2.right : Vector2.left) * speed * Time.deltaTime);
        if (movingRight)
        {
            changeTimer = changeTimer - Time.deltaTime;
            if (changeTimer <= 0)
            {
                movingRight = false;
                changeTimer = DirectionTimer;
            }
        }
        if (!movingRight)
        {
            changeTimer = changeTimer - Time.deltaTime;
            if (changeTimer <= 0)
            {
                movingRight = true;
                changeTimer = DirectionTimer;
            }
        }
    }
}
