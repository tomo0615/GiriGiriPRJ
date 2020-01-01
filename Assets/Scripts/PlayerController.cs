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

        //移動
        this.UpdateAsObservable()
            .Select(x => _playerInputs.MoveDirection())
            .Subscribe(x => _playerMover.Move(x));
    }
}
