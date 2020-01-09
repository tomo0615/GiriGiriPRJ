using UniRx;
using UnityEngine;

public class GameUIPresenter : MonoBehaviour
{
    #region score
    private ScoreModel _scoreModel = null;

    [SerializeField]
    private ScoreView _scoreView = null;
    #endregion

    #region start
    [SerializeField]
    private StartModel _startModel = null;

    [SerializeField]
    private StartView _startView = null;
    #endregion

    #region levelUp
    [SerializeField]
    private EnemyGenerator _levelUpModel = null;

    [SerializeField]
    private LevelUpView _levelUpView = null;
    #endregion

    private void Awake()
    {
        _scoreModel = new ScoreModel();
    }

    private void Start()
    {
        //StartPrezenter
        _startModel.startRP 
            .Where(value => value == true)
            .Subscribe(value =>
            {
                _startView.ViewStart()
                .Subscribe(_ => _startModel.isStart = false);
            });

        //ScorePresenter
        _scoreModel.Scoring
            .Subscribe(_scoreView.ViewScoreText)
            .AddTo(gameObject);

        //LevelUpPresenter
        _levelUpModel.levelRP
            .Where(value => value > 0)
            .Subscribe(_ =>
            {
                StartCoroutine(_levelUpView.ViewLevelUp());
            });
    }
}
