public class Teleporting : MonoBehaviour
{
    public float xaxis, yaxis;
    bool rightSide, leftSide, isInVehicle, isInCollider, canPressKey, isInWater;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && rightSide && !isInVehicle)
        {
            transform.position = new Vector2(transform.position.x - xaxis, transform.position.y + yaxis);
        }
        else if (Input.GetKeyDown(KeyCode.E) && leftSide && !isInVehicle)
        {
            transform.position = new Vector2(transform.position.x + xaxis, transform.position.y + yaxis);
        }

        if (isInVehicle && isInWater)
        {
            canPressKey = true;
        }
        else if (!isInVehicle && isInWater)
        {
            canPressKey = false;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isInCollider)
            {
                if (!isInVehicle)
                {
                    if (!canPressKey)
                    {
                        isInVehicle = true;
                    }
                }
            }
            else if (isInVehicle)
            {
                if (canPressKey)
                {
                    isInVehicle = false;
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RightSide"))
        {
            rightSide = true;
        }
        else if (other.gameObject.CompareTag("LeftSide"))
        {
            leftSide = true;
        }
        else if (other.gameObject.CompareTag("Submarine"))
        {
            isInCollider = true;
        }
        else if (other.gameObject.CompareTag("Water"))
        {
            isInWater = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RightSide"))
        {
            rightSide = false;
        }
        else if (other.gameObject.CompareTag("LeftSide"))
        {
            leftSide = false;
        }
        else if (other.gameObject.CompareTag("Submarine"))
        {
            isInCollider = false;
        }
        else if (other.gameObject.CompareTag("Water"))
        {
            isInWater = false;
        }
    }
}
