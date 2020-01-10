using UniRx;
using UnityEngine;

public class ScorePresenter : MonoBehaviour
{
    private ScoreModel _scoreModel = null;

    [SerializeField]
    private ScoreView _scoreView = null;

    private void Awake()
    {
        _scoreModel = new ScoreModel();
    }

    private void Start()
    {
        //スコア更新購読
        _scoreModel.Scoring
            .Where(value => value > 0)
            .Subscribe(_scoreView.ViewScoreText)
            .AddTo(gameObject);
    }

    public void OnChangeScore(int value)
    {
        _scoreModel.UpdateScoreValue(value);
    }
}