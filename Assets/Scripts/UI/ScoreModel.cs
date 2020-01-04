using UniRx;
using UnityEngine;

public class ScoreModel : MonoBehaviour
{
    public IntReactiveProperty scoreRP = new IntReactiveProperty();

    public int scoreValue 
    {
        get { return scoreRP.Value; }
        set { scoreRP.Value = value; }
    }
}
