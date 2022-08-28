public class CharacterController2D : MonoBehaviour
{
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	
	[SerializeField] private bool m_AirControl = false;							
	[SerializeField] private LayerMask m_WhatIsGround;							
	[SerializeField] private Transform m_GroundCheck;							
	[SerializeField] private Transform m_CeilingCheck;							
	[SerializeField] private Collider2D m_CrouchDisableCollider;				

	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  
	private Vector3 velocity = Vector3.zero;

	public static CharacterController2D chacterController;

	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

	}




    void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Water") == true)
		{
			m_Rigidbody2D.gravityScale = 0f;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Water") == true)
		{
			m_Rigidbody2D.gravityScale = 1f;
		}
	}

    public void Swim(float swim)
	{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(swim * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (swim > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (swim < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
	}


	public void Sprint(float sprint)
    {
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(sprint * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (sprint > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (sprint < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
	}

	public void Move(float move, bool crouch, bool jump)
	{
			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
	}


	public void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
