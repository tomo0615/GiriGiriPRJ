using UnityEngine;
using System.Collections;
public class GiriGiriCollider : MonoBehaviour, ITouchable
{
    private Collider _collider;

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
        //Playerのボーナスを加算
        GameEffectManager.Instance.OnGenelateEffect(transform.position + Vector3.up/2, EffectType.GiriGiri);
        Debug.Log("Bonus!");
    }
}
