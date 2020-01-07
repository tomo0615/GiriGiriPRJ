using UniRx;
using UnityEngine;

public class GameUIPresenter : MonoBehaviour
{
    #region score
    [SerializeField]
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
        _scoreModel.scoreRP
            .Subscribe(value =>
            {
                _scoreView.ViewText(value);
            });

        //LevelUpPresenter
        _levelUpModel.levelRP
            .Where(value => value > 0)
            .Subscribe(_ =>
            {
                StartCoroutine(_levelUpView.ViewLevelUp());
            });
    }
}
