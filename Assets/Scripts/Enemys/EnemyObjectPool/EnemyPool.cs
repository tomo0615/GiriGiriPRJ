using UnityEngine;
using UniRx.Toolkit;
public class EnemyPool : ObjectPool<BaseEnemy>
{
    private readonly Transform _transform;

    private readonly BaseEnemy _baseEnemy;

    public EnemyPool(Transform transform, BaseEnemy baseEnemy)
    {
        _transform = transform;

        _baseEnemy = baseEnemy;
    }


    protected override BaseEnemy CreateInstance()
    {
        var enemy = GameObject.Instantiate(_baseEnemy);

        //一つにまとめるため
        enemy.transform.SetParent(_transform);

        return enemy;
    }
}
