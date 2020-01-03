using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Collections.Generic;
using System.Collections;

public class EnemyGenerator : MonoBehaviour 
{ 
    private Dictionary<int, EnemyPool> _enemyPool
        = new Dictionary<int, EnemyPool>();

    [SerializeField]
    private EnemyTable _EnemyTable = null;

    private Transform _myTransform;

    [SerializeField]
    private float coroutineWaitTime = 2f;

    void Start()
    {
        _myTransform = GetComponent<Transform>();

        InitializeEnemyList();

        StartCoroutine(GenerateCoroutine());
    }

    private void InitializeEnemyList()
    {
        //すべてのエフェクトをディクショナリに格納
        for (int i = 0; i < _EnemyTable.enemyList.Count; i++)
        {
            _enemyPool.Add(i, new EnemyPool(_myTransform, _EnemyTable.enemyList[i])); ;
        }

        //オブジェクトが破棄されたときにプールを破棄できるようにする
        foreach (var value in _enemyPool.Values)
        {
            this.OnDestroyAsObservable()
                .Subscribe(_ => value.Dispose());
        }
    }

    private void GenerateEnemy(int type)
    {
        var enemy = _enemyPool[type].Rent();

        enemy.Fall()
            .Subscribe(_ =>
            {
                _enemyPool[type].Return(enemy);
            });
    }

    private IEnumerator GenerateCoroutine()
    {
        while (true)
        {
            var randomType = Random.Range(0, _enemyPool.Keys.Count);
            GenerateEnemy(randomType);
            yield return new WaitForSeconds(coroutineWaitTime);
        }
    }
}
