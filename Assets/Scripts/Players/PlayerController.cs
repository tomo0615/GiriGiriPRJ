using UnityEngine;
using UniRx;
using UniRx.Triggers;

public enum InputType
{
    PC,
    Mobile
}

public class PlayerController : MonoBehaviour,IPlayerCollider
{
    private IPlayerInput _playerInput;
    private PlayerMover _playerMover;
    private PlayerAnimator _playerAnimator;

    [SerializeField]
    private InputType inputType;

    [SerializeField]
    private GiriGiriCollider _giriGiriCollider = null;

    [SerializeField]
    private YoketaCollider _yoketaCollider = null;

    [SerializeField]
    private CameraController _cameraController = null;

    private void Awake()
    {
        if(inputType == InputType.PC)
        {
            _playerInput = new PlayerPCInput();
        }
        else if(inputType == InputType.Mobile)
        {
            _playerInput = new PlayerMobileInput();
        }

        _playerMover = new PlayerMover(this.transform);
        _playerAnimator = new PlayerAnimator(this.transform);
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

                _playerAnimator.DOMoveAnimation();

                StartCoroutine(_giriGiriCollider.SwitchCollider());//ギリギリ判定を出す
            });
    }

    public void Collided()
    {
        _cameraController.ShakeCamera(5f);

        //死亡演出
        GameEffectManager.Instance.OnGenelateEffect(transform.position, EffectType.DeadEffect);
        SoundManager.Instance.PlaySoundOneShot(SoundType.dead);

        //Scoreが入らないように
        _yoketaCollider.gameObject.SetActive(false);
        Destroy(gameObject);

        GameStateManager.Instance.SetGameState(GameState.End);
        //Debug.Log("GameOver");
    }
}
