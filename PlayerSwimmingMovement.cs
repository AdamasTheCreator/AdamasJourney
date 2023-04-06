public class SwimmingMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    private float swimSpeed = 0f;
    private bool isInRange = false;
    private bool isInVehicle = false;

    void Update()
    {
        float horizontalSwim = Input.GetAxisRaw("Swimming") * swimSpeed;
        animator.SetFloat("Swim", Mathf.Abs(horizontalSwim));

        if (isInVehicle)
        {
            if (Input.GetKey(KeyCode.LeftShift) && StaminaBar.currentStamina >= 20)
            {
                StaminaBar.instance.UseStamina(5);
                swimSpeed = 150;
                animator.SetBool("SubNitro", true);
                animator.SetBool("SubSpeed", false);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                swimSpeed = 40;
                animator.SetBool("SubNitro", false);
                animator.SetBool("SubSpeed", true);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                animator.SetBool("SubNitro", true);
                animator.SetBool("SubSpeed", false);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                animator.SetBool("SubNitro", false);
                animator.SetBool("SubSpeed", true);
            }
            else
            {
                animator.SetBool("SubSpeed", false);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            swimSpeed = 20;
        }
        if (other.gameObject.CompareTag("Submarine"))
        {
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Water"))
        {
            swimSpeed = 0;
        }
        if (other.gameObject.CompareTag("Submarine"))
        {
            isInRange = false;
        }
    }

    void FixedUpdate()
    {
        controller.Swim(Input.GetAxisRaw("Swimming") * swimSpeed * Time.fixedDeltaTime);
    }
}
