using UnityEngine;
using System.Collections;
public class GiriGiriCollider : MonoBehaviour, IPlayerCollider
{ 
    [SerializeField]
    private ScorePresenter _scorePresenter = null;

    [SerializeField]
    private PraisePresenter _praisePresenter = null;

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

    //Player移動時に呼び出し
    public IEnumerator SwitchCollider()
    {
        _collider.enabled = true;

        yield return new WaitForSeconds(0.25f);

        _collider.enabled = false;
    }

    public void Collided()
    {
        //スコア更新
        _scorePresenter.OnChangeScore(BONUS_SCORE);

        //Praiseを表示
        _praisePresenter.OnPraisePlayer();

        //Effect発生
        GameEffectManager.Instance
            .OnGenelateEffect(transform.position + Vector3.up / 2, EffectType.GiriGiri);

        //ぎりぎりの音を再生
        SoundManager.Instance.PlaySoundOneShot(SoundType.girigiri);
    }
}
