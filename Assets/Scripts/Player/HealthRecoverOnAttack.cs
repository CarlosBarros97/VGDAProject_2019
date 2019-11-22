using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthRecoverOnAttack : MonoBehaviour
{
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator Knockback(float knockDuration, float knockPower, Vector3 knockDirection)
    {
        float timer = 0;

        while (knockDuration > timer)
        {
            timer += Time.deltaTime;
            rb2d.AddForce(new Vector3(knockDirection.x * -100, knockDirection.y * knockPower, transform.position.z));
        }

        yield return 0;
    }
}
