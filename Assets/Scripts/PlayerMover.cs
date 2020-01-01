using UnityEngine;
using DG.Tweening;

public class PlayerMover
{
    private readonly Transform _transform;

    public PlayerMover(Transform transform)
    {
        _transform = transform;
    }

    public void Move(Vector3 direction)
    {
        var endValue = _transform.position + direction;
        //TODO:終わるまで呼ばれないようにする
        _transform.DOMove(endValue, 0.1f);
    }
}
