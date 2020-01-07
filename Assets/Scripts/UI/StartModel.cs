using UniRx;
using UnityEngine;

public class StartModel : MonoBehaviour
{
    public BoolReactiveProperty startRP = new BoolReactiveProperty();

    public bool isStart
    {
        get { return startRP.Value; }
        set { startRP.Value = value; }
    }
}
