using UnityEngine;

public class PlayerPCInput : IPlayerInput
{
    private float _horizontal;

    public void Inputting()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    }

    public Vector3 MoveDirection() =>
        new Vector3((int)_horizontal *2, 0);
}
