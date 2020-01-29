using UnityEngine;
using DG.Tweening;
using TMPro;
using UniRx;
using System;

public class StartView : MonoBehaviour 
{
    private RectTransform _rectTransform;

    [SerializeField]
    private TextMeshProUGUI startSignText = null;

    [SerializeField]
    private HowToViewOnMobile _howToOnMobile = null;

    [SerializeField]
    private HowToViewOnPC _howToOnPC = null;

    [SerializeField]
    private float StartSignTimeValue = 3.0f;

    [SerializeField]
    private InputType playerInputType = InputType.PC;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public IObservable<Unit> ViewStartSign()
    {
        startSignText.text = "READY";


        //TODO:関数化する
        if (playerInputType == InputType.PC)
        {
            StartCoroutine(_howToOnPC.ViewHowTo());
        }
        else if(playerInputType == InputType.Mobile)
        {
            StartCoroutine(_howToOnMobile.ViewHowTo());
        }

        transform.DOScale(_rectTransform.localScale / 2f, StartSignTimeValue * 2/3)
            .OnComplete(() =>
            {
                startSignText.text = "GO!";

                transform.DOScale(_rectTransform.localScale * 10f, StartSignTimeValue * 0.1f)
                .OnUpdate(() =>
                {
                    startSignText.color -= new Color(0, 0, 0, 0.1f);
                });
            });

        return Observable
            .Timer(TimeSpan.FromSeconds(StartSignTimeValue))
            .ForEachAsync(_=> Debug.Log("GameStart"));
    }
}
