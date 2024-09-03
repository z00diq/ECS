using UnityEngine;

[CreateAssetMenu(fileName = "Enemy Config", menuName = "Configs/Enemy")]
public class EnemyConfig : PlayerConfig
{
    [SerializeField] private int _damage;
    [SerializeField] private float _reloadTime;

    public int Damage =>_damage;
    public float RealoadTime => _reloadTime;
}
