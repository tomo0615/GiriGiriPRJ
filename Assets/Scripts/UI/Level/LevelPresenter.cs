using UniRx;
using UnityEngine;

public class LevelPresenter : MonoBehaviour
{
    private LevelModel _levelModel = null;

    [SerializeField]
    private LevelView _levelView = null;

    private void Awake()
    {
        _levelModel = new LevelModel();
    }

    void Start()
    {
        _levelModel.Leveling
            .Where(value => value > 1)
            .Subscribe(_ =>
            {
                StartCoroutine(_levelView.ViewLevelUp());
            });
        /*
        _scoreModel.Scoring
            .Where(value => (value / 10) == difficultLevel + 1 && (value / 10) != 0)
            .Subscribe(_ =>
            {
                coroutineWaitTime *= 0.9f;
                difficultLevel++;
            });
            */
    }

    public void OnChangeLevel(int value)
    {
        _levelModel.UpdateLevelValue(value);
    }
}
