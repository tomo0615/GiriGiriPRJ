using UniRx;
using UnityEngine;
using System.Collections;

public enum GameState
{
    Start,
    End
}
public class GameStateManager : SingletonMonoBehaviour<GameStateManager>
{
    [SerializeField]
    private GameUIPresenter _gameUIPresenter = null;

    [SerializeField]
    private EnemyGenerator _enemyGenerator = null;//StartState用

    [SerializeField]
    private ResultView _resultView = null;

    //ResultUIのコンポーネントを。。。
    private void Start()
    {
        SetGameState(GameState.Start);
    }

    public void SetGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                StartGame();
                break;
            case GameState.End:
                StopAllCoroutines();
                StartCoroutine(EndGame());
                break;
        }
    }

    private void StartGame()
    {
        _gameUIPresenter.OnChangeStartFlag(true);

        SoundManager.Instance.PlayBGM();
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);

        _resultView.ViewResult();
    }
}
