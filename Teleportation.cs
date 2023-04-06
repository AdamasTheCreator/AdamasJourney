public class Teleporting : MonoBehaviour
{
    public float xaxis, yaxis;
    bool rightSide, leftSide, isInVehicle, isInCollider, canPressKey, isInWater;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (rightSide && !isInVehicle)
                transform.position = new Vector2(transform.position.x - xaxis, transform.position.y + yaxis);
            else if (leftSide && !isInVehicle)
                transform.position = new Vector2(transform.position.x + xaxis, transform.position.y + yaxis);

            if (isInWater)
                canPressKey = isInVehicle ? true : false;
        }

        if (isInCollider && !isInVehicle && !canPressKey)
            isInVehicle = true;
        else if (isInVehicle && canPressKey)
            isInVehicle = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("RightSide"))
            rightSide = true;
        else if (other.CompareTag("LeftSide"))
            leftSide = true;
        else if (other.CompareTag("Submarine"))
            isInCollider = true;
        else if (other.CompareTag("Water"))
            isInWater = true;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("RightSide"))
            rightSide = false;
        else if (other.CompareTag("LeftSide"))
            leftSide = false;
        else if (other.CompareTag("Submarine"))
            isInCollider = false;
        else if (other.CompareTag("Water"))
            isInWater = false;
    }
}

