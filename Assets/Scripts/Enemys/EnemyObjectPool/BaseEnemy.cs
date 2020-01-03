using UnityEngine;
using DG.Tweening;
using UniRx;
using System;

public abstract class BaseEnemy : MonoBehaviour
{
    [SerializeField]
    private float fallTime= 2f;

    private Vector2 SetPosition()
    {
        int axisX = UnityEngine.Random.Range(-1,2) * 2;//-2, 0, 2のどれか
        return new Vector2(axisX, 6);
    }

    public IObservable<Unit> Fall()
    {
        transform.position = SetPosition();

        Vector2 fallPosition = transform.position;
        fallPosition.y *= -1;

        var tween = transform.DOMove(fallPosition, fallTime);

        return Observable
            .Timer(TimeSpan.FromSeconds(fallTime))
            .ForEachAsync(_ => Debug.Log("よけた"));
    }

    private void OnTriggerEnter(Collider other)
    {
        var touchable = other.GetComponent<ITouchable>();

        if (touchable != null)
        {
            touchable.Touch();
        }
    }
}
