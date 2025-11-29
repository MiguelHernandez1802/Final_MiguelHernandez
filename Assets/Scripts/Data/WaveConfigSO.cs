using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewWaveConfig", menuName = "WaveSystem/Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [System.Serializable]
    public struct EnemyGroup
    {
        public EnemyProfileSO enemyProfile;
        public int count;
    }

    public List<EnemyGroup> enemies;
    public float timeBetweenSpawns = 1f;
    public float timeToNextWave = 5f;
}

