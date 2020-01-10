using UnityEngine;
using System.Collections;
using UniRx;

public enum GameState
{
    Start,
    End
}
public class GameStateManager : SingletonMonoBehaviour<GameStateManager>
{
    [SerializeField]
    private StartView _startView = null;

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
        SoundManager.Instance.PlayBGM();

        //Startカウント終了あとにEnemyの生成を開始
        _startView.ViewStartSign()
        .Subscribe(_ => StartCoroutine(_enemyGenerator.GenerateCoroutine()));
    }

    private IEnumerator EndGame()
    {
        yield return new WaitForSeconds(2f);

        _resultView.ViewResult();
    }
}
