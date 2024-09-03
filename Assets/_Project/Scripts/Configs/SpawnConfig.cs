using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Spawn Config", menuName = "Configs/EnemySpawn")]
public class SpawnConfig : ScriptableObject
{
    [SerializeField] private float _spawnTime;
    [SerializeField] private float _distance;

    public float SpawnTime => _spawnTime;
    public float Distance => _distance;
}
