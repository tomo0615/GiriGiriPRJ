using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Create EnemyTable")]
public class EnemyTable : ScriptableObject
{
    public List<BaseEnemy> enemyList
        = new List<BaseEnemy>();

}
