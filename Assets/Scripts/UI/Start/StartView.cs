using UnityEngine;
using DG.Tweening;
using TMPro;
using UniRx;
using System;
using System.Collections;

public class StartView : MonoBehaviour
{
    private RectTransform _rectTransform;

    [SerializeField]
    private TextMeshProUGUI startSignText = null;

    [SerializeField]
    private TextMeshProUGUI howToText = null;

    [SerializeField]
    private float StartSignTimeValue = 3.5f;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
    }

    public IObservable<Unit> ViewStartSign()
    {
        startSignText.text = "READY";
        
        StartCoroutine(ViewHowTo());

        transform.DOScale(_rectTransform.localScale / 2f, StartSignTimeValue * 2/3)
            .OnComplete(() =>
            {
                startSignText.text = "GO!";

                transform.DOScale(_rectTransform.localScale * 4f, StartSignTimeValue * 1/3)
                .OnComplete(() => 
                {
                    startSignText.text = "";
                });
            });

        return Observable
            .Timer(TimeSpan.FromSeconds(StartSignTimeValue))
            .ForEachAsync(_=> Debug.Log("GameStart"));
    }

    public IEnumerator ViewHowTo()
    {
        int flashCount = 3;

        while (flashCount > 0)
        {
            howToText.text = "< Dodge! >";
            yield return new WaitForSeconds(0.5f);
            howToText.text = "";
            yield return new WaitForSeconds(0.5f);
            flashCount--;
        }
    }
}
