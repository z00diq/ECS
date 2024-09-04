﻿using Assets._Project.Scripts.ECS.Camera;
using Assets._Project.Scripts.ECS.Followable;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public class Initializer:MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private SpawnConfig _spawnConfig;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private CameraProvider _cameraProvider;

        private EnemySpawner _enemySpawner;

        private void Start()
        {
            World world = World.Default;

            PlayerSpawner playerSpawner = new PlayerSpawner(_playerConfig, _spawnPoint.position);
            Entity player = playerSpawner.Create();
            Transform playerView = player.GetComponent<TransformComponent>().Transform;
            _enemySpawner = new EnemySpawner(_enemyConfig,  player, _spawnConfig);
            Entity camera = _cameraProvider.Entity;
            camera.SetComponent(new FollowComponent { Target = playerView });

            //SystemsGroup systemGroup = world.CreateSystemsGroup();
            //InputSystem inputSystem = new();
            //InputProviderSystem inputProviderSystem = new();
            //FollowSystem followSystem = new();
            //MoveSystem moveSystem = new();

            //systemGroup.AddSystem(InputSystem);

        }

        private void Update()
        {
            _enemySpawner.Spawn();
        }
    }
}
