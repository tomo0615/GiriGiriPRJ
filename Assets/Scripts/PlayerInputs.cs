using UnityEngine;

public class PlayerInputs : IPlayerInputs
{
    private float _horizontal;

    public void Inputting()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    }

    public Vector3 MoveDirection() =>
        new Vector3(_horizontal, 0);
}
