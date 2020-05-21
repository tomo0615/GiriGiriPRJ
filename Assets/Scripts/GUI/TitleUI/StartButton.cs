public class StartButton : BaseButton
{
    protected override void OnPushed()
    {
        base.OnPushed();

        LoadSceneManager.Instance.OnLoadGameScene(SceneType.Game);
    }
}
