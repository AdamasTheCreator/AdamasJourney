public class Teleporting : MonoBehaviour
{
    public float xaxis;
    public float yaxis;
    bool rightSide;
    bool leftSide;
    bool isInVehicle;
    bool isInCollider;
    bool canPressKey;
    bool isInWater;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true && rightSide == true && isInVehicle == false)
        {
            transform.position = new Vector2(transform.position.x - xaxis, transform.position.y + yaxis);
        }
        if (Input.GetKeyDown(KeyCode.E) == true && leftSide == true && isInVehicle == false)
        {
            transform.position = new Vector2(transform.position.x + xaxis, transform.position.y + yaxis);
        }

        if (isInVehicle == true & isInWater == true)
        {
            canPressKey = true;
        }
        if (isInVehicle == false & isInWater == true)
        {
            canPressKey = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInCollider == true)
            {
                if (isInVehicle == false)
                {
                    if (canPressKey == false)
                    {
                        isInVehicle = true;
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInCollider == false)
            {
                if (isInVehicle == true)
                {
                    if (canPressKey == true)
                    {
                        isInVehicle = false;
                    }
                }
            }
        }
    }





    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RightSide") == true)
        {
            rightSide = true;
        }
        if (other.gameObject.CompareTag("LeftSide") == true)
        {
            leftSide = true;
        }
        if (other.gameObject.CompareTag("Submarine") == true)
        {
            isInCollider = true;
        }
        if (other.gameObject.CompareTag("Water") == true)
        {
            isInWater = true;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RightSide") == true)
        {
            rightSide = false;
        }
        if (other.gameObject.CompareTag("LeftSide") == true)
        {
            leftSide = false;
        }
        if (other.gameObject.CompareTag("Submarine") == true)
        {
            isInCollider = false;
        }
        if (other.gameObject.CompareTag("Water") == true)
        {
            isInWater = false;

        }
    }

}
