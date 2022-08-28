public class SwimmingMovement : MonoBehaviour
{
	public CharacterController2D controller;
	public Animator animator;

	private float swimSpeed = 0f;

	float horizontalSwim = 0f;
	bool isInRange;
	bool isInVehicle;



	void Start()
    {
		isInVehicle = false;
    }

    void Update()
	{

		horizontalSwim = Input.GetAxisRaw("Swimming") * swimSpeed;

		animator.SetFloat("Swim", Mathf.Abs(horizontalSwim));

		if (Input.GetKey(KeyCode.LeftShift) == false & Input.GetKey(KeyCode.D) == false & Input.GetKey(KeyCode.A) == false & Input.GetKey(KeyCode.W) == false & Input.GetKey(KeyCode.S) == false & isInVehicle == true)
		{
			animator.SetBool("SubSpeed", false);
		}

		if (Input.GetKey(KeyCode.LeftShift) == true & Input.GetKey(KeyCode.D) == true & isInVehicle == true & StaminaBar.currentStamina >= 20)
		{
			StaminaBar.instance.UseStamina(5);
			swimSpeed = 150;
			animator.SetBool("SubNitro", true);
			animator.SetBool("SubSpeed", false);
		}
		if (Input.GetKey(KeyCode.LeftShift) == true & Input.GetKey(KeyCode.D) == true & isInVehicle == true & StaminaBar.currentStamina <= 20)
		{
			swimSpeed = 40;
			animator.SetBool("SubNitro", false);
			animator.SetBool("SubSpeed", true);
		}

		if (Input.GetKey(KeyCode.LeftShift) == false & Input.GetKey(KeyCode.D) == true & isInVehicle == true)
		{
			swimSpeed = 40;
			animator.SetBool("SubNitro", false);
			animator.SetBool("SubSpeed", true);
		}

		if (Input.GetKey(KeyCode.LeftShift) == true & Input.GetKey(KeyCode.A) == true & isInVehicle == true & StaminaBar.currentStamina >= 20)
		{
			StaminaBar.instance.UseStamina(5);
			swimSpeed = 150;
			animator.SetBool("SubNitro", true);
			animator.SetBool("SubSpeed", false);
		}
		if (Input.GetKey(KeyCode.LeftShift) == true & Input.GetKey(KeyCode.A) == true & isInVehicle == true & StaminaBar.currentStamina <= 20)
		{
			swimSpeed = 40;
			animator.SetBool("SubNitro", false);
			animator.SetBool("SubSpeed", true);
		}
		if (Input.GetKey(KeyCode.LeftShift) == false & Input.GetKey(KeyCode.A) == true & isInVehicle == true)
		{
			swimSpeed = 40;
			animator.SetBool("SubNitro", false);
			animator.SetBool("SubSpeed", true);
		}

		if (Input.GetKey(KeyCode.LeftShift) == true & Input.GetKey(KeyCode.W) == true & isInVehicle == true)
		{
			animator.SetBool("SubNitro", true);
			animator.SetBool("SubSpeed", false);
		}
		if (Input.GetKey(KeyCode.LeftShift) == false & Input.GetKey(KeyCode.W) == true & isInVehicle == true)
		{
			animator.SetBool("SubNitro", false);
			animator.SetBool("SubSpeed", true);
		}

		if (Input.GetKey(KeyCode.LeftShift) == true & Input.GetKey(KeyCode.S) == true & isInVehicle == true)
		{
			animator.SetBool("SubNitro", true);
			animator.SetBool("SubSpeed", false);
		}
		if (Input.GetKey(KeyCode.LeftShift) == false & Input.GetKey(KeyCode.S) == true & isInVehicle == true)
		{
			animator.SetBool("SubNitro", false);
			animator.SetBool("SubSpeed", true);
		}


		if (Input.GetKeyDown(KeyCode.E))
		{
			if (isInRange == true)
			{
				if (isInVehicle == false)
				{
					isInVehicle = true;
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.E))
        {
			if (isInRange == false)
			{
				if (isInVehicle == true)
				{
					isInVehicle = false;
				}
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Water") == true)
		{
			swimSpeed = 20;
		}
		if (other.gameObject.CompareTag("Submarine") == true)
		{
			isInRange = true;
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.CompareTag("Water") == true)
		{
			swimSpeed = 0;
		}
		if (other.gameObject.CompareTag("Submarine") == true)
		{
			isInRange = false;
		}
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Swim(horizontalSwim * Time.fixedDeltaTime);
	}
}
