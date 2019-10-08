using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed= 6f;                  // Speed of player along x transform
    [SerializeField] private GameObject _fireballPrefab;        
    [SerializeField] private float _fireRate = 0.5f;            // How often can player shoot skill
    [SerializeField] private float jumpForce = 400f;            // Force added when player jumps
    [SerializeField] private int _health = 100;                 // Player health counter
    [SerializeField] private bool _AirControl = true;           // Allowing control while jumping
    [SerializeField] private LayerMask _WhatIsGround;           // Mask determining what is ground to the char

    private Transform _GroundCheck;     // Position marking where to check if player is grounded
    private bool _isGrounded;           // Check if player is grounded
    private Transform _CheckCeiling;    // Position marking where to check for ceilings
    private Rigidbody2D _Rigidbody2D;
    private bool _FacingRight = true;   // check where the player is currently facing

    private Vector3 _fireballOffset = new Vector2(0, 0.8f);
    private float _canFire = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // take the current position = new position (0, 0, 0)
        transform.position = new Vector2(0, 0);
    }

    void Update()
    {
        CalculateMovement();
        /*
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
        {
            FireLaser();
        }
        */
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // new Vector3(1, 0, 0)
        if(horizontalInput > 0 && !_FacingRight)
        {
            Flip();
        }
        else if(horizontalInput < 0 && _FacingRight)
        {
            Flip();
        }
        transform.Translate(Vector2.right * horizontalInput * _speed * Time.deltaTime);

        
        // Clamping the top and bottom bounds
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, 0f, 7.75f));

        // Horizontal Teleport out of bounds
        if (transform.position.x > 16.6f)
        { 
            transform.position = new Vector2(-16.5f, transform.position.y);
        }
        else if (transform.position.x < -16.5f)
        {
            transform.position = new Vector2(16.6f, transform.position.y);
        }
    }

    private void FireMagic()
    {
     _canFire = Time.time + _fireRate;
     Instantiate(_fireballPrefab, transform.position + _fireballOffset, Quaternion.identity); 
    }

    private void Flip()
    {
        // Switch the way the player is pointed
        _FacingRight = !_FacingRight;

        // Multiply the x scale by -1 to flip the image
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    public void Damage()
    {
        _health --;

        if(_health < 1)
        {
            Destroy(this.gameObject);
        }
    }
}
