using System;
using UnityEngine;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        [SerializeField] private float m_MaxSpeed = 20f;                    // Base speed the player can travel in the x axis.
        [SerializeField] private float m_JumpForce = 400f;                  // Amount of force added when the player jumps.      
        [SerializeField] private float m_JumpPushForce = 10f;               // Wall jump force
        [SerializeField] private bool m_AirControl = false;                 // Whether or not a player can steer while jumping;
        [SerializeField] private LayerMask m_WhatIsGround;                  // A mask determining what is ground to the character
        [SerializeField] private LayerMask m_WhatIsWall;                    // Mask determining what is a wall
        [Range(1, 2)] [SerializeField] private float m_SlideSpeed = 1.2f;   // Speed for sliding
        [Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;  // Amount of maxSpeed applied to crouching movement. 1 = 100%
        [Range(1, 2)] [SerializeField] private float m_SprintSpeed = 1.5f;  // Players sprint speed

        private Transform m_GroundCheck;        // A position marking where to check if the player is grounded.
        const float k_GroundedRadius = .2f;     // Radius of the overlap circle to determine if grounded
        private bool m_Grounded;                // Whether or not the player is grounded.
        private Transform m_CeilingCheck;       // A position marking where to check for ceilings
        const float k_CeilingRadius = .01f;     // Radius of the overlap circle to determine if the player can stand up
        private Transform m_WallCheck;          // A position marking where to check for ceilings
        const float k_WallTouchRadius = 0.1f;   // Radius of the overlap circle to determine if player touches wall
        private bool m_TouchingWall = false;    // Will only trigger when player touches a wall layered component
        private Animator m_Anim;                // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        private bool m_FacingRight = true;      // For determining which way the player is currently facing.
        private bool _isSliding = false;        // Check to see if player is sliding
        private bool _doubleJump = false;       // Allows for double jump mechanic

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_CeilingCheck = transform.Find("CeilingCheck");
            m_WallCheck = transform.Find("WallCheck");
            
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
        }


        private void FixedUpdate()
        {
            m_Grounded = false;
            m_TouchingWall = false;
            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
            m_TouchingWall = Physics2D.OverlapCircle(m_WallCheck.position, k_WallTouchRadius, m_WhatIsWall);
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject != gameObject)
                {
                    m_Grounded = true;
                    _doubleJump = false;
                }
            }

            
            if (m_TouchingWall)
            {
                m_Grounded = false;
                _doubleJump = false;
            }

            
            m_Anim.SetBool("Ground", m_Grounded);

            // Set the vertical animation
            m_Anim.SetFloat("vSpeed", m_Rigidbody2D.velocity.y);
        }


        public void Move(float move, bool crouch, bool jump, bool sprint)
        {
            // If crouching, check to see if the character can stand up
            if (!crouch && m_Anim.GetBool("Crouch"))
            {
                // If the character has a ceiling preventing them from standing up, keep them crouching
                if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
                {
                    crouch = true;
                }
            }

            // Set whether or not the character is crouching in the animator
            m_Anim.SetBool("Crouch", crouch);

            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                
                if (sprint && crouch)
                {
                    // Reduce the speed if crouching by the crouchSpeed multiplier
                    move = (move * m_SlideSpeed * m_SprintSpeed);
                }
                else if (sprint)
                {
                    // Increase the speed if sprinting
                    move = (move * m_SprintSpeed);
                }
                else if (crouch)
                {
                    move = (move * m_CrouchSpeed);
                }
                
                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move*m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                    // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }
            // If the player should jump...
            if ((m_Grounded || !_doubleJump) && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));

                if(!_doubleJump && !m_Grounded)
                {
                    _doubleJump = true;
                }
            }
            // If player is touching a wall, jump
            if(m_TouchingWall && jump)
            {
                WallJump();
            }
            Debug.Log("Am I touching the wall: " + m_TouchingWall);
            Debug.Log("Did I jump again: " + _doubleJump);
            Debug.Log("Am I grounded: " + m_Grounded);

        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        private void WallJump()
        {
            m_Rigidbody2D.AddForce(new Vector2(m_JumpPushForce, m_JumpForce));
        }
    }
}
