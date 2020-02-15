using UnityEngine;
using UniRx;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Start()
    {
        _button.OnClickAsObservable()
            .Subscribe(_ => OnPushed())
            .AddTo(gameObject);
    }

    protected virtual void OnPushed()
    {
        //SE再生
    }
}
