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
			Vector3 targetVelocity = new Vector2(swim * 10f, m_Rigidbody2D.velocity.y);

			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

			if (swim > 0 && !m_FacingRight)
			{
				Flip();
			}
			else if (swim < 0 && m_FacingRight)
			{
				Flip();
			}
	}


	public void Sprint(float sprint)
    {

			Vector3 targetVelocity = new Vector2(sprint * 10f, m_Rigidbody2D.velocity.y);

			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);


			if (sprint > 0 && !m_FacingRight)
			{
				Flip();
			}
			else if (sprint < 0 && m_FacingRight)
			{
				Flip();
			}
	}

	public void Move(float move, bool crouch, bool jump)
	{
	
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);

			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, m_MovementSmoothing);

			if (move > 0 && !m_FacingRight)
			{
				Flip();
			}
			else if (move < 0 && m_FacingRight)
			{
				Flip();
			}
	}


	public void Flip()
	{

		m_FacingRight = !m_FacingRight;

		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
