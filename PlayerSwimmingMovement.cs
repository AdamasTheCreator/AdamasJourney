public class SwimmingMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    private float swimSpeed = 0f;

    float horizontalSwim = 0f;
    bool isInRange = false;
    bool isInVehicle = false;

    void Update()
    {
        horizontalSwim = Input.GetAxisRaw("Swimming") * swimSpeed;
        animator.SetFloat("Swim", Mathf.Abs(horizontalSwim));

        if (Input.GetKey(KeyCode.LeftShift)) {
            if (Input.GetKey(KeyCode.D) && isInVehicle && StaminaBar.currentStamina >= 20) {
                StaminaBar.instance.UseStamina(5);
                swimSpeed = 150;
                animator.SetBool("SubNitro", true);
                animator.SetBool("SubSpeed", false);
            } else if (Input.GetKey(KeyCode.A) && isInVehicle && StaminaBar.currentStamina >= 20) {
                StaminaBar.instance.UseStamina(5);
                swimSpeed = 150;
                animator.SetBool("SubNitro", true);
                animator.SetBool("SubSpeed", false);
            } else if (isInVehicle && StaminaBar.currentStamina <= 20) {
                swimSpeed = 40;
                animator.SetBool("SubNitro", false);
                animator.SetBool("SubSpeed", true);
            }
        } else if (Input.GetKey(KeyCode.D) && isInVehicle) {
            swimSpeed = 40;
            animator.SetBool("SubNitro", false);
            animator.SetBool("SubSpeed", true);
        } else if (Input.GetKey(KeyCode.A) && isInVehicle) {
            swimSpeed = 40;
            animator.SetBool("SubNitro", false);
            animator.SetBool("SubSpeed", true);
        } else if (Input.GetKey(KeyCode.W) && isInVehicle) {
            animator.SetBool("SubNitro", true);
            animator.SetBool("SubSpeed", false);
        } else if (Input.GetKey(KeyCode.S) && isInVehicle) {
            animator.SetBool("SubNitro", false);
            animator.SetBool("SubSpeed", true);
        } else if (!Input.GetKey(KeyCode.LeftShift) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S) && isInVehicle) {
            animator.SetBool("SubSpeed", false);
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
    controller.Swim(horizontalSwim * Time.fixedDeltaTime);
    }
}
