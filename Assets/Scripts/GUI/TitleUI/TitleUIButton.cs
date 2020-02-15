using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TitleUIButton : BaseButton
{
    [SerializeField]
    private RectTransform displayWindow = null;

    protected override void OnPushed()
    {
        base.OnPushed();

        //Windowの表示
    }

    private void SetActiveWindow()
    {

    }
}
