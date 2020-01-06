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
    
    /*テスト用
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isStart = true;
        }
    }
    */
}
