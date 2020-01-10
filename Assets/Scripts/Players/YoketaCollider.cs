using UnityEngine;

public class YoketaCollider : MonoBehaviour, ITouchable
{
    [SerializeField]
    private ScorePresenter _scorePresenter = null;

    private const int NORMAL_SCORE = 1;

    public void Touch()
    {
        _scorePresenter.OnChangeScore(NORMAL_SCORE);
    }
}
