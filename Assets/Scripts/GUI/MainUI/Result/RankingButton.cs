using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingButton : MonoBehaviour
{
    [SerializeField]
    private ScorePresenter _scorePresenter = null;
    
    public void OnClickRankingButton()
    {
        int scoreValue = _scorePresenter.GetScoreValue();
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(scoreValue);
    }
}
