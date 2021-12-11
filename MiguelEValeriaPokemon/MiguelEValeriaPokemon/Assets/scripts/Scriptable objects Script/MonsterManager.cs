using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MonsterManager", menuName = "MiguelThings/MonsterManager")]
public class MonsterManager : ScriptableObject
{
    [SerializeField]
    public Monster [] allMonsters;
}
