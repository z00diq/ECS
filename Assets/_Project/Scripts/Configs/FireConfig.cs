using UnityEngine;

[CreateAssetMenu(fileName = "Player Fire Config", menuName = "Configs/Player/Fire")]
public class FireConfig : ScriptableObject
{
    [SerializeField] public float LifeTime;
    [SerializeField] private TransformProvider _prefab;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    public float Speed => _speed;
    public TransformProvider Prefab => _prefab;
    public float FireRate => _fireRate;
    public int Damage => _damage;
}