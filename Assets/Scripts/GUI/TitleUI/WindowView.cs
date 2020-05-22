using UnityEngine;
using DG.Tweening;

public class WindowView : MonoBehaviour
{
    private RectTransform _rectTransform = default;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public void SetActiveWindow(bool isActive)
    {
        float endValue = 2000;

        if (isActive)
        {
            endValue = 0;
        }

        _rectTransform.DOLocalMoveY(endValue, 0.25f);
    }
}
