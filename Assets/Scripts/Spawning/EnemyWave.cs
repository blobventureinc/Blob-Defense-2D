using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct EnemyWave
{
    public GameObject enemyPrefab;
    public int ammount;
    public float interval;
    public float startTime;
}
