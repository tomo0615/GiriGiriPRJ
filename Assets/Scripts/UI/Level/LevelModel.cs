using UniRx;

public class LevelModel : ILevelUpdatable
{
    private ReactiveProperty<int> _leveling;

    public IReadOnlyReactiveProperty<int> Leveling
    {
        get { return _leveling; }
    }

    public LevelModel()
    {
        _leveling = new ReactiveProperty<int>(1);
    }

    public void UpdateLevelValue(int value)
    {
        _leveling.Value += value;
    }

    public void UpdateLevel()
    {
        throw new System.NotImplementedException();
    }
}
