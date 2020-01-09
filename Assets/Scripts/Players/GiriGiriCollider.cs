using UnityEngine;
using System.Collections;
public class GiriGiriCollider : MonoBehaviour, ITouchable
{ 
    [SerializeField]
    private GameUIPresenter _gameUIPresenter = null;

    private Collider _collider;

    private const int BONUS_SCORE = 5;

    private void Awake()
    {
        _collider = GetComponent<Collider>();
    }
    private void Start()
    {
        _collider.enabled = false;
    }

    public IEnumerator SwitchCollider()
    {
        _collider.enabled = true;

        yield return new WaitForSeconds(0.25f);

        _collider.enabled = false;
    }


    public void Touch()
    {
        _gameUIPresenter.OnChangeScore(BONUS_SCORE);

        GameEffectManager.Instance
            .OnGenelateEffect(transform.position + Vector3.up/2, EffectType.GiriGiri);

        SoundManager.Instance.PlaySoundOneShot(SoundType.girigiri);
    }
}
