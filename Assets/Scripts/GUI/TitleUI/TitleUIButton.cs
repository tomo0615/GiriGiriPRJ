using UnityEngine;
using DG.Tweening;

public class TitleUIButton : BaseButton
{
    [SerializeField]
    private RectTransform displayWindow = null;

    [SerializeField]
    private bool displayableWindow = true;

    protected override void OnPushed()
    {
        base.OnPushed();

        //Windowの表示
        SetActiveWindow();
        //Windowの表示アニメーション

    }

    private void SetActiveWindow()
    {
        displayWindow.gameObject.SetActive(displayableWindow);
    }
}
