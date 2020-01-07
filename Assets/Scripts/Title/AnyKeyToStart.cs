using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class AnyKeyToStart : MonoBehaviour
{
    private void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.anyKey)
            .Subscribe(_ => 
            LoadSceneManager.Instance.OnLoadGameScene(SceneType.Game));
    }
}
