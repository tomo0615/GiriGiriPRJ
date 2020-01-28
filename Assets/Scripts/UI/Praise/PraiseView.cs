﻿using TMPro;
using UnityEngine;
using DG.Tweening;

public class PraiseView : MonoBehaviour
{
    [SerializeField]
    private float punchTime = 0.5f;

    [SerializeField]
    private float punchScale = 1.5f;

    private TextMeshProUGUI praiseText;

    private RectTransform _rectTransform;

    private bool isPunch = false;

    private void Awake()
    {
        praiseText = GetComponent<TextMeshProUGUI>();

        _rectTransform = GetComponent<RectTransform>();
    }

    public void ViewPraiseWord(string word)
    {
        praiseText.text = word;
        
        PunchText();
    }

    private void PunchText()
    {
        //重複して呼ばれないように
        if (isPunch) return;
        isPunch = true;

        transform.DOScale(_rectTransform.localScale * punchScale, punchTime / 2)
            .OnComplete(() =>
            {
                transform.DOScale(_rectTransform.localScale / punchScale, punchTime / 2)
                .OnComplete(() =>
                {
                    isPunch = false;

                    praiseText.text = "";
                });
            });
    }
}