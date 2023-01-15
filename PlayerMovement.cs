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

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKey(KeyCode.LeftShift)) {
            if (Input.GetKey(KeyCode.D) && !isInWater && StaminaBar.currentStamina >= 20) {
                sprintSpeed = 55;
                runSpeed = 0f;
                StaminaBar.instance.UseStamina(2);
            } else if (Input.GetKey(KeyCode.A) && !isInWater && StaminaBar.currentStamina >= 20) {
                sprintSpeed = 55;
                runSpeed = 0f;
                StaminaBar.instance.UseStamina(2);
            } else if (StaminaBar.currentStamina <= 20) {
                sprintSpeed = 0;
                runSpeed = 30f;
            }
        } else if (Input.GetKey(KeyCode.D) && !isInWater) {
            sprintSpeed = 0;
            runSpeed = 30f;
        } else if (Input.GetKey(KeyCode.A) && !isInWater) {
            sprintSpeed = 0;
            runSpeed = 30f;
        }

        if (isInWater && !isInVehicle && !oxygenLevel) {
            OxygenBar.O.UseOxygen(1);
        } else if (isInWater && !isInVehicle && oxygenLevel && OxygenBar.currentOxygen <= 1999) {
            OxygenBar.O.UseOxygen(-10);
        } else if (isInWater && !isInVehicle && oxygenLevel && OxygenBar.currentOxygen >= 1999) {
            OxygenBar.O.UseOxygen(0);
        }
    }
}
