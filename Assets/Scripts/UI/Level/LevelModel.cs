using UniRx;

public class LevelModel
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
}
