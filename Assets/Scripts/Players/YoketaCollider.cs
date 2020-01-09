using UnityEngine;

public class YoketaCollider : MonoBehaviour, ITouchable
{
    private ScoreModel _scoreModel = null;

    private void Awake()
    {
        _scoreModel = new ScoreModel();
    }

    public void Touch()
    {
        _scoreModel.UpdateScoreValue(1);
    }
}
