using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerController : MonoBehaviour,ITouchable
{
    private IPlayerInputs _playerInputs;
    private PlayerMover _playerMover;

    [SerializeField]
    private GiriGiriCollider _collider = null;

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
            .Subscribe(x =>
            {
                _playerMover.Move(x);

                _collider.enabled = true;
            });
    }


    public void Touch()
    {
        //GameOverになる
        Debug.Log("GameOver");
    }
}
