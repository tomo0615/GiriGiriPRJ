using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerController : MonoBehaviour
{
    private IPlayerInputs _playerInputs;
    private PlayerMover _playerMover;

    private void Awake()
    {
        _playerInputs = new PlayerInputs();
        _playerMover = new PlayerMover(this.transform);
    }

    private void Start()
    {
        //入力受付
        this.UpdateAsObservable()
            .Subscribe(_ => _playerInputs.Inputting());

        this.ObserveEveryValueChanged(_ => _playerInputs.MoveDirection())
            .Select(x => transform.position + _playerInputs.MoveDirection())
            .Where(x => Mathf.Abs(x.x) < 3)
            .Subscribe(x => _playerMover.Move(x));
    }
}
