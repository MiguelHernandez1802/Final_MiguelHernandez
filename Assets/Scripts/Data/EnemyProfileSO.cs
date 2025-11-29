using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyProfile", menuName = "WaveSystem/Enemy Profile")]
public class EnemyProfileSO : ScriptableObject
{
    public string enemyName = "Enemigo";
    public float speed = 5f;
    public float health = 10f;
    public GameObject prefab;
}