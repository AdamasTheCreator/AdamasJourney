public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 20f;
    public float sprintSpeed = 0f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    bool isInVehicle = false;
    bool isInArea = false;
    bool isInWater = false;
    bool oxygenLevel = false;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftShift) && !isInWater && StaminaBar.currentStamina >= 20) {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) {
                sprintSpeed = 55;
                runSpeed = 0f;
                StaminaBar.instance.UseStamina(2);
            } else {
                sprintSpeed = 0;
                runSpeed = 30f;
            }
        } else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A)) && !isInWater) {
            sprintSpeed = 0;
            runSpeed = 30f;
        }

        if (isInWater && !isInVehicle) {
            if (!oxygenLevel)
                OxygenBar.O.UseOxygen(1);
            else if (OxygenBar.currentOxygen <= 1999)
                OxygenBar.O.UseOxygen(-10);
            else
                OxygenBar.O.UseOxygen(0);
        }
    }
}
