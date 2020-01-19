using UnityEngine;
using DG.Tweening;

public class PlayerAnimator
{
    private Transform _transform;

    public PlayerAnimator(Transform transform)
    {
        _transform = transform;
    }

    public void DOMoveAnimation()
    {
        Vector3 horizontalLongScale = new Vector3(_transform.localScale.x, _transform.localScale.y * 0.3f);

        //Vector3 verticalLongScale = new Vector3(_transform.localScale.x * 0.5f, _transform.localScale.y);

        _transform.DOScale(horizontalLongScale, 0.1f)
            .OnComplete(() =>
            {
                _transform.DOScale(1f, 0.1f);
            });  
    }
}
