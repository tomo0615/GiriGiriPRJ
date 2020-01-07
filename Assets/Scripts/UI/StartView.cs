using UnityEngine;
using DG.Tweening;
using TMPro;
using UniRx;
using System;

public class StartView : MonoBehaviour
{
    private RectTransform _rectTransform;

    private TextMeshProUGUI startText;

    [SerializeField]
    private HowToView _howToView = null;

    [SerializeField]
    private float waitTimeValue = 3.5f;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        startText = GetComponent<TextMeshProUGUI>();
    }

    public IObservable<Unit> ViewStart()
    {
        startText.text = "READY";

        StartCoroutine(_howToView.ViewHowTo());

        transform.DOScale(_rectTransform.localScale / 2f, waitTimeValue * 2/3)
            .OnComplete(() =>
            {
                startText.text = "GO!";

                transform.DOScale(_rectTransform.localScale * 4f,  waitTimeValue * 1/3)
                .OnComplete(() => 
                {
                    startText.text = "";
                });
            });

        return Observable
            .Timer(TimeSpan.FromSeconds(waitTimeValue))
            .ForEachAsync(_=> Debug.Log("GameStart"));
    }
}
