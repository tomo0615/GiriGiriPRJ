using UnityEngine;

public class PlayerMobileInput : IPlayerInput
{
    private Vector3 touchStartPosition;
    private Vector3 touchEndPosition;

    private float directionX;

    public void Inputting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPosition = new Vector3(Input.mousePosition.x, 0);
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPosition = new Vector3(Input.mousePosition.x, 0);

            directionX = touchEndPosition.x - touchStartPosition.x;
        }
        else
        {
            directionX = 0;
        }
    }

    public Vector3 MoveDirection()
        => new Vector3(directionX, 0).normalized * 2;
}
