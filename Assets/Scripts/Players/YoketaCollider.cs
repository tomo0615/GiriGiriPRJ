using UnityEngine;

public class YoketaCollider : MonoBehaviour, IPlayerCollider
{
    [SerializeField]
    private ScorePresenter _scorePresenter = null;

    private const int NORMAL_SCORE = 1;

    public void Collided()
    {
        _scorePresenter.OnChangeScore(NORMAL_SCORE);
    }
}
