using UnityEngine;
using UniRx;
using UniRx.Triggers;
using System.Collections.Generic;

public class EnemyGenerator : MonoBehaviour 
{ 
    private Dictionary<EnemyType, EnemyPool> _enemyPool
        = new Dictionary<EnemyType, EnemyPool>();

    [SerializeField]
    private EnemyTable _EnemyTable = null;

    private Transform _myTransform;

    void Start()
    {
        _myTransform = GetComponent<Transform>();

        InitializeEnemyList();
    }

    private void InitializeEnemyList()
    {
        //すべてのエフェクトをディクショナリに格納
        for (int i = 0; i < _EnemyTable.enemyList.Count; i++)
        {
            _enemyPool.Add((EnemyType)i, new EnemyPool(_myTransform, _EnemyTable.enemyList[i])); ;
        }

        //オブジェクトが破棄されたときにプールを破棄できるようにする
        foreach (var value in _enemyPool.Values)
        {
            this.OnDestroyAsObservable().Subscribe(_ => value.Dispose());
        }
    }

    public void GenerateEnemy(EnemyType type)
    {
        var enemy = _enemyPool[type].Rent();

        enemy.Fall()
            .Subscribe(_ =>
            {
                _enemyPool[type].Return(enemy);
            });
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)) 
        {
            //テスト用
            GenerateEnemy(EnemyType.Normal);
        }
    }
}
