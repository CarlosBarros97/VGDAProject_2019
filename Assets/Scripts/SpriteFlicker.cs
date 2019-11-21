using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlicker : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private float FlickeringTimer = 0.1f;
    private bool SpriteDisabled = false;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteFlickering();
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

