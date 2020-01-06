using UnityEngine;
using DG.Tweening;
using TMPro;

public class StartView : MonoBehaviour
{
    private RectTransform _rectTransform;

    private TextMeshProUGUI startText;

    [SerializeField]
    private HowToView _howToView = null;

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();

        startText = GetComponent<TextMeshProUGUI>();
    }

    public void ViewStart()
    {
        startText.text = "READY";

        StartCoroutine(_howToView.ViewHowTo());

        transform.DOScale(_rectTransform.localScale / 2f, 3)
            .OnComplete(() =>
            {
                startText.text = "GO!";

                transform.DOScale(_rectTransform.localScale * 4f, 0.5f)
                .OnComplete(() => startText.text = "");
            });
    }
}
