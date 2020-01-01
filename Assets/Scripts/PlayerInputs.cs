using UnityEngine;

public class PlayerInputs : IPlayerInputs
{
    private float _horizontal;

    public void Inputting()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");
    }

    public Vector2 MoveDirection() =>
        new Vector2(_horizontal, 0);
}
