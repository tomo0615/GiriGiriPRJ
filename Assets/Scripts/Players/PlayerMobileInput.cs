using UnityEngine;

public class PlayerMobileInput : IPlayerInput
{
    private Vector3 touchStartPos;
    private Vector3 touchEndPos;

    private Vector3 moveDirection = Vector3.zero;

    public void Inputting()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector3(Input.mousePosition.x, 0);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector3(Input.mousePosition.x, 0);
           
            GetDirection();
        }
    }

    public Vector3 MoveDirection()
        => moveDirection;

    private Vector3 GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;

        moveDirection = new Vector3(directionX, 0).normalized * 2;

        return moveDirection;
    }
}
