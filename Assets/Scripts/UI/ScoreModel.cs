using UniRx;

public class ScoreModel
{
    private ReactiveProperty<int> _scoring = new ReactiveProperty<int>();

    public IReadOnlyReactiveProperty<int> Scoring
    {
        get { return _scoring; }
    }

    public ScoreModel()
    {
        _scoring = new ReactiveProperty<int>(0);
    }

    public void UpdateScoreValue(int value)
    {
        _scoring.Value += value;
    }
}
