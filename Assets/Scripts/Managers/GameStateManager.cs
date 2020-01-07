using UniRx;
using UnityEngine;

public enum GameState
{
    Start,
    End
}
public class GameStateManager : SingletonMonoBehaviour<GameStateManager>
{
    //private GameState currentGameState;

    [SerializeField]
    private StartModel _startModel = null; //StartState用

    [SerializeField]
    private EnemyGenerator _enemyGenerator = null;//StartState用

    //ResultUIのコンポーネントを。。。
    private void Start()
    {
        SetGameState(GameState.Start);

        _startModel.startRP
            .Where(value => value == false)
            .Subscribe(_ =>
            {
                StartCoroutine(_enemyGenerator.GenerateCoroutine());
            });
    }

    public void SetGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                StartGame();
                break;
            case GameState.End:
                EndGame();
                break;
        }
    }

    private void StartGame()
    {
        _startModel.isStart = true;
    }

    private void EndGame()
    {
        StopAllCoroutines();

        //Resultの表示
    }
}
