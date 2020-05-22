using UnityEngine;

public class TitleUIButton : BaseButton
{
    [SerializeField]
    private WindowView _windowView = default;

    [SerializeField]
    private bool isDisplayableWindow = true;

    protected override void OnPushed()
    {
        base.OnPushed();

        SetActiveWindow();
    }

    private void SetActiveWindow()
    {
        _windowView.SetActiveWindow(isDisplayableWindow);
    }
}
