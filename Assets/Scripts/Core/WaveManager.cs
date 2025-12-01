using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour
{
    public enum SpawnMode { Automatic, ManualDebug }

    [Header("Configuración")]
    public SpawnMode mode = SpawnMode.Automatic;
    public Transform spawnPoint;
    public List<WaveConfigSO> waves;

    [HideInInspector] public EnemyProfileSO testProfile;

    private GameState currentState = GameState.Idle;

    private void Start()
    {
        if (mode == SpawnMode.Automatic)
        {
            StartCoroutine(GameLoop());
        }
    }

    private IEnumerator GameLoop()
    {
        currentState = GameState.Idle;

        foreach (var wave in waves)
        {
            ChangeState(GameState.SpawningWave);

            foreach (var group in wave.enemies)
            {
                for (int i = 0; i < group.count; i++)
                {
                    SpawnEnemy(group.enemyProfile);
                    yield return new WaitForSeconds(wave.timeBetweenSpawns);
                }
            }

            ChangeState(GameState.WaitingForNextWave);
            yield return new WaitForSeconds(wave.timeToNextWave);
        }

        ChangeState(GameState.LevelCompleted);
    }

    private void ChangeState(GameState newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameState.SpawningWave:
                Debug.Log("Estado: SPAWNING");
                break;
            case GameState.WaitingForNextWave:
                Debug.Log("Estado: WAITING");
                break;
            case GameState.LevelCompleted:
                Debug.Log("Estado: WIN");
                break;
        }
    }

    public void SpawnEnemy(EnemyProfileSO profile)
    {
        if (profile != null && profile.prefab != null)
        {
            GameObject go = Instantiate(profile.prefab, spawnPoint.position, Quaternion.identity);
            go.GetComponent<EnemyBase>().Initialize(profile);
        }
    }
}