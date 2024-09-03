﻿using UnityEngine;

[CreateAssetMenu(fileName = "Player Fire Config", menuName = "Configs/Player/Fire")]
public class FireConfig : ScriptableObject
{
    [SerializeField] private FireBallProvider _prefab;
    [SerializeField] private float _fireRate;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    public float Speed => _speed;
    public FireBallProvider Prefab => _prefab;
    public float FireRate => _fireRate;
    public int Damage => _damage;
}