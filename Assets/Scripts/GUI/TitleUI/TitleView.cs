using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TitleView : MonoBehaviour
{
    [SerializeField]
    private float punchDuration = 1f;

    [SerializeField]
    private float changeSizeRation = 1.1f;

    private RectTransform _rectTransform;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        PunchText();
    }

    private void PunchText()
    {
        var largeScale = _rectTransform.localScale * changeSizeRation;
        var smallScale = _rectTransform.localScale / changeSizeRation;

        //DoLarge
        _rectTransform.DOScale(largeScale, punchDuration)
            .OnComplete(() =>
            {
                //DoSmall
                _rectTransform.DOScale(smallScale, punchDuration);

            }).SetLoops(-1);//無限ループ
    }
}
