using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class PlayerController : MonoBehaviour,IPlayerCollider
{
    private IPlayerInput _playerInput;
    private PlayerMover _playerMover;

    [SerializeField]
    private GiriGiriCollider _collider = null;

    [SerializeField]
    private CameraController _cameraController = null;

    private void Awake()
    {
        _playerInput = new PlayerPCInput();
        _playerMover = new PlayerMover(this.transform);
    }

    private void Start()
    {
        //入力受付
        this.UpdateAsObservable()
            .Subscribe(_ => _playerInput.Inputting());

        //移動
        this.ObserveEveryValueChanged(_ => _playerInput.MoveDirection())
            .Select(x => transform.position + x)
            .Where(x => Mathf.Abs(x.x) < 3)
            .Subscribe(x =>
            {
                _playerMover.Move(x);

                SoundManager.Instance.PlaySoundOneShot(SoundType.move);

                StartCoroutine(_collider.SwitchCollider());//ギリギリ判定を出す
            });
    }

    public void Collided()
    {
        _cameraController.ShakeCamera(10f);

        GameEffectManager.Instance.OnGenelateEffect(transform.position, EffectType.DeadEffect);

        Destroy(gameObject);

        GameStateManager.Instance.SetGameState(GameState.End);

        SoundManager.Instance.PlaySoundOneShot(SoundType.dead);

        Debug.Log("GameOver");
    }
}
