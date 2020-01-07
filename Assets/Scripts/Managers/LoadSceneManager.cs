using UnityEngine.SceneManagement;

public enum SceneType 
{
    Title,
    Game
}

public class LoadSceneManager : SingletonMonoBehaviour<LoadSceneManager>
{
    private string sceneName = "";

    void Start()
    {
        DontDestroyOnLoad(this); //共通で使うため
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(sceneName);
    }

    #region　UIボタン用関数
    public void OnClickSceneButton(string name)
    {
        sceneName = name;

        LoadGameScene();
    }
    #endregion

    #region 他クラス呼び出し用
    public void OnLoadGameScene(SceneType scene)
    {
        sceneName = scene.ToString();

        LoadGameScene();
    }
    #endregion
}
