using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerController : MonoBehaviour,ITouchable
{
    private IPlayerInputs _playerInputs;
    private PlayerMover _playerMover;

    [SerializeField]
    private GiriGiriCollider _collider = null;

    [SerializeField]
    private CameraController _cameraController = null;

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
        this.ObserveEveryValueChanged(_ => _playerInputs.MoveDirection())
            .Select(x => transform.position + _playerInputs.MoveDirection())
            .Where(x => Mathf.Abs(x.x) < 3)
            .Subscribe(x =>
            {
                _playerMover.Move(x);

                SoundManager.Instance.PlaySoundOneShot(SoundType.move);

                StartCoroutine(_collider.SwitchCollider());//ギリギリ判定を出す
            });
    }


    public void Touch()
    {
        _cameraController.ShakeCamera(10f);

        GameEffectManager.Instance.OnGenelateEffect(transform.position, EffectType.DeadEffect);

        Destroy(gameObject);

        GameStateManager.Instance.SetGameState(GameState.End);

        SoundManager.Instance.PlaySoundOneShot(SoundType.dead);

        Debug.Log("GameOver");
    }
}
