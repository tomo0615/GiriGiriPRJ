using UniRx;

public class StartModel
{
    public ReactiveProperty<bool> _starting = new BoolReactiveProperty();

    public IReadOnlyReactiveProperty<bool> Starting
    {
        get { return _starting; }
    }

    public void SetStartFlag(bool flag)
    {
        _starting.Value = flag;
    }
}
