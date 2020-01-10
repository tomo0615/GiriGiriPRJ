using UnityEngine;
using System.Collections;
public class GiriGiriCollider : MonoBehaviour, ITouchable
{ 
    [SerializeField]
    private ScorePresenter _scorePresenter = null;

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


    public void Touch()
    {
        //スコア更新
        _scorePresenter.OnChangeScore(BONUS_SCORE);

        //Effect発生
        GameEffectManager.Instance
            .OnGenelateEffect(transform.position + Vector3.up/2, EffectType.GiriGiri);

        //ぎりぎりの音を再生
        SoundManager.Instance.PlaySoundOneShot(SoundType.girigiri);
    }
}
