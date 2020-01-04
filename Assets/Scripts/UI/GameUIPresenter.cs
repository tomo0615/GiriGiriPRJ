using UniRx;
using UnityEngine;

public class GameUIPresenter : MonoBehaviour
{
    [SerializeField]
    private ScoreModel _scoreModel = null;

    [SerializeField]
    private ScoreView _scoreView = null;

    private void Start()
    {
        _scoreModel.scoreRP
            .Subscribe(value =>
            {
                _scoreView.ViewText(value);
            });
    }
}
