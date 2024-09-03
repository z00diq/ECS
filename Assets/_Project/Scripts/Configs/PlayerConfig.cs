using UnityEngine;

[CreateAssetMenu(fileName ="Player Config", menuName = "Configs/Player/Base")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _health;


    public GameObject Prefab => _prefab;
    public float Speed => _speed;
    public int Health => _health;
}
