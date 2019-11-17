using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolScript : MonoBehaviour
{
    public float speed;
    //Raycast distance
    public float RaycastDistance;
    private bool movingRight = true;
    //Added groundLayer instead of GameObject Tag for Performance
    public LayerMask GroundLayer;

    //enemy stats
    [SerializeField]
    public int CurrentHealth = 1;

    [SerializeField]
    Animator anim;
    

    // Update is called once per frame
    void Update()
    {

        transform.Translate(((movingRight) ? Vector2.right : Vector2.left) * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(transform.position, Vector2.down, RaycastDistance, GroundLayer);

        anim.SetBool("MovingRight",movingRight);

        if (!groundInfo)
        {
            Debug.Log("I am not hitting anything");
            if (movingRight == true)
            {
                Debug.Log("changing to move left");
                movingRight = false;
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
            else
            {
                Debug.Log("changing to move right");
                movingRight = true;
                gameObject.transform.localScale = new Vector3(-gameObject.transform.localScale.x, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
            }
        }

        if(CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Damage(int d)
    {
        CurrentHealth -= d;
        
    }

}
