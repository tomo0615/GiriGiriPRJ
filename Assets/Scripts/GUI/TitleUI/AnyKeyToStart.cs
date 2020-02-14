using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class AnyKeyToStart : MonoBehaviour
{
    private void Start()
    { 
        //TODO:設定ボタンを実装するため、直す
        /*
        this.UpdateAsObservable()
            .Where(_ => Input.anyKey)
            .Subscribe(_ => 
            LoadSceneManager.Instance.OnLoadGameScene(SceneType.Game));
        */
    }
}
