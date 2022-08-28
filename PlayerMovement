public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;
	public Animator animator;
	

	public float runSpeed = 20f;
	public float sprintSpeed = 0f;

	float horizontalMove = 0f;
	float horizontalSprint = 0f;
	bool jump = false;
	bool crouch = false;
	bool isInVehicle;
	bool isInArea;
	bool isInWater;
	bool oxygenLevel;

	// Update is called once per frame

	private void Start()
	{
		isInVehicle = false;
	}

	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		horizontalSprint = Input.GetAxisRaw("Horizontal") * sprintSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		animator.SetFloat("Sprint", Mathf.Abs(horizontalSprint));



		if (Input.GetKey(KeyCode.LeftShift) == true & Input.GetKey(KeyCode.D) == true & isInWater == false & StaminaBar.currentStamina >= 20)
		{
			sprintSpeed = 55;
			runSpeed = 0f;
			StaminaBar.instance.UseStamina(2);
		}
		if (Input.GetKey(KeyCode.LeftShift) == true & Input.GetKey(KeyCode.D) == true & isInWater == false & StaminaBar.currentStamina <= 20)
		{
			sprintSpeed = 0;
			runSpeed = 30f;
		}
		if (Input.GetKey(KeyCode.LeftShift) == false & Input.GetKey(KeyCode.D) == true & isInVehicle == true & isInWater == true)
		{
			sprintSpeed = 0;
			runSpeed = 0f;
		}

		if (Input.GetKey(KeyCode.LeftShift) == false & Input.GetKey(KeyCode.D) == true & isInWater == false)
		{
			sprintSpeed = 0;
			runSpeed = 30f;
		}

		if (Input.GetKey(KeyCode.LeftShift) == true & Input.GetKey(KeyCode.A) == true & isInWater == false & StaminaBar.currentStamina >= 20)
		{
			sprintSpeed = 55;
			runSpeed = 0f;
			StaminaBar.instance.UseStamina(2);
		}
		if (Input.GetKey(KeyCode.LeftShift) == true & Input.GetKey(KeyCode.A) == true & isInWater == false & StaminaBar.currentStamina <= 20)
		{
			sprintSpeed = 0;
			runSpeed = 30f;
		}
		if (Input.GetKey(KeyCode.LeftShift) == false & Input.GetKey(KeyCode.A) == true & isInVehicle == true & isInWater == true)
		{
			sprintSpeed = 0;
			runSpeed = 0f;
		}

		if (Input.GetKey(KeyCode.LeftShift) == false & Input.GetKey(KeyCode.A) == true & isInWater == false)
		{
			sprintSpeed = 0;
			runSpeed = 30f;
		}

        if(isInWater == true & isInVehicle == false & oxygenLevel == false)
        {
			OxygenBar.O.UseOxygen(1);
		}
		if (isInWater == true & isInVehicle == false & oxygenLevel == true & OxygenBar.currentOxygen <= 1999)
		{
			OxygenBar.O.UseOxygen(-10);
		}
		if (isInWater == true & isInVehicle == false & oxygenLevel == true & OxygenBar.currentOxygen >= 1999)
		{
			OxygenBar.O.UseOxygen(0);
		}
		if (isInWater == true & isInVehicle == true & OxygenBar.currentOxygen <= 1999)
		{
			OxygenBar.O.UseOxygen(-10);
		}
		if (isInWater == true & isInVehicle == true & OxygenBar.currentOxygen >= 1999)
		{
			OxygenBar.O.UseOxygen(0);
		}

		if (Input.GetKeyDown(KeyCode.E))
		{
			if (isInArea == true)
			{
				if (isInVehicle == false)
				{
					animator.SetBool("IsInVehicle", true);
					isInVehicle = true;
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.E))
        {
			if (isInArea == false)
            {
				if (isInVehicle == true)
				{
					animator.SetBool("IsInVehicle", false);
					isInVehicle = false;
				}
			}
        }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Submarine") == true)
		{
			isInArea = true;
		}
		if (other.gameObject.CompareTag("OxygenLevel") == true)
		{
			oxygenLevel = true;
		}
		if (other.gameObject.CompareTag("Water") == true & isInVehicle == false)
		{
			animator.SetBool("IdleSwimming", true);
			runSpeed = 0;
			animator.SetBool("SubIdle", false);
			isInWater = true;
		}

		if (other.gameObject.CompareTag("Water") == true & isInVehicle == true)
		{
			animator.SetBool("IdleSwimming", false);
			animator.SetBool("SubIdle", true);
			isInWater = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Submarine") == true)
		{
			isInArea = false;
		}
		if (other.gameObject.CompareTag("OxygenLevel") == true)
		{
			oxygenLevel = false;
		}
		if (other.gameObject.CompareTag("Water") == true & isInVehicle == false)
		{
			animator.SetBool("IdleSwimming", false);
			runSpeed = 20;
			animator.SetBool("SubIdle", false);
			isInWater = false;
		}
		if (other.gameObject.CompareTag("Water") == true & isInVehicle == true)
		{
			animator.SetBool("IdleSwimming", false);
			animator.SetBool("SubIdle", true);
			isInWater = false;
		}
	}

	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);

		controller.Sprint(horizontalSprint * Time.fixedDeltaTime);
	}
}
