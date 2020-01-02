using UnityEngine;
using DG.Tweening;

public class PlayerMover
{
    private readonly Transform _transform;

    private bool isMoving = false;
    
    public PlayerMover(Transform transform)
    {
        _transform = transform;
    }

    public void Move(Vector3 direction)
    {
        if (isMoving) return;

        isMoving = true;

        _transform.DOMove(direction, 0.1f)
            .OnComplete(() =>
            {
                isMoving = false;
            });
 
    }
}
