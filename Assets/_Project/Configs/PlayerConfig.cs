using UnityEngine;

[CreateAssetMenu(fileName ="Player Config", menuName = "Configs/Player")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _prefab;

    public GameObject Prefab => _prefab;
    public float Speed => _speed;
}
