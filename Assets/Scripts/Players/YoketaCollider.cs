using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YoketaCollider : MonoBehaviour, ITouchable
{
    [SerializeField]
    private ScoreModel _scoreModel = null;

    public void Touch()
    {
        _scoreModel.scoreValue++;
    }
}
