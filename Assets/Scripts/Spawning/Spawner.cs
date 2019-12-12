using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using PathCreation;

[RequireComponent(typeof(PathCreator))]
public class Spawner : MonoBehaviour
{
    public Wave[] waves;
    [HideInInspector]
    public int curentWave;

    private int deathCount = 0;
    private int enemyWaveCount = 10;
    public UnityEvent waveEnded;

    private PathCreator pathCreator;

    public bool HasNextWave => curentWave < waves.Length-1;

    public void SpawnNextWave() 
    {
        if(HasNextWave) 
        {
            curentWave++;
            SpawnWave(waves[curentWave]);
        } 
        else 
        {
            Debug.LogWarning("Tryed to spawn Next wave but there are no next Waves");
        }
    }

    public void SpawnWave(Wave wave) {
        foreach(EnemyWave enemyWave in wave.enemyWaves) 
        {
            StartCoroutine(SpawnEnemyWave(enemyWave));
        }
    }

    public IEnumerator SpawnEnemyWave(EnemyWave enemyWave) 
    {
        deathCount = 0;
        Debug.Log("DeathCount: " + deathCount);
        enemyWaveCount = enemyWave.ammount;
        Debug.Log("EnemyWaveAmount: " + enemyWave.ammount);
        yield return new WaitForSeconds(enemyWave.startTime);
        for(int i = 0; i < enemyWave.ammount; i++) 
        {
            GameObject enemy = Instantiate(enemyWave.enemyPrefab, pathCreator.path.GetPointAtDistance(0f), Quaternion.identity, transform);
            enemy.GetComponent<HealthSystem>().onDeath.AddListener(CountDeath);
            WalkAlongPath walkAlongPath = enemy.GetComponentInChildren<WalkAlongPath>();
            walkAlongPath.pathCreator = pathCreator;
            yield return new WaitForSeconds(enemyWave.interval);
        }
    }

    public void CountDeath() {
        deathCount++;
        Debug.Log("DeathCount: " + deathCount);
    }

    private void Update() {
        if (deathCount == enemyWaveCount) {
            waveEnded.Invoke();
            deathCount = 0;
        }
    }

    void OnEnable() 
    {
        pathCreator = GetComponent<PathCreator>();
        curentWave = -1;
    }
}
