using UniRx;
using UnityEngine;

public class LevelPresenter : MonoBehaviour
{
    private LevelModel _levelModel = null;

    [SerializeField]
    private LevelView _levelView = null;

    [SerializeField]
    private EnemyGenerator _enemyGenerator = null;

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
    }

    public void OnChangeLevel(int value)
    {
        _levelModel.UpdateLevel(value);

        _enemyGenerator.OnUpGenerateInterval();
    }

    public int GetCurrentLevel()
    {
        return _levelModel.Leveling.Value;
    }
}
