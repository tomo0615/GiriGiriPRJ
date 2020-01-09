using UnityEngine;

public class YoketaCollider : MonoBehaviour, ITouchable
{
    [SerializeField]
    private GameUIPresenter _gameUIPresenter = null;

    private ScoreModel _scoreModel = null;

    private const int NORMAL_SCORE = 1;

    private void Awake()
    {
        _scoreModel = new ScoreModel();
    }

    public void Touch()
    {
        _gameUIPresenter.OnChangeScore(NORMAL_SCORE);
    }
}
