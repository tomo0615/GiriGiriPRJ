using UniRx;
using UnityEngine;

public class GameUIPresenter : MonoBehaviour
{
    #region start
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
        _startModel = new StartModel();
    }

    private void Start()
    {
        //StartPrezenter
        _startModel.Starting
            .Where(value => value == true)
            .Subscribe(value =>
            {
                _startView.ViewStart()
                .Subscribe(_ => StartCoroutine(_levelUpModel.GenerateCoroutine()));
            });

        //LevelUpPresenter
        _levelUpModel.levelRP
            .Where(value => value > 0)
            .Subscribe(_ =>
            {
                StartCoroutine(_levelUpView.ViewLevelUp());
            });
    }

    public void  OnChangeStartFlag(bool flag)
    {
        _startModel.SetStartFlag(flag);
    }
}
