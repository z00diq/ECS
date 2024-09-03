using Assets._Project.Scripts.ECS.Camera;
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
            PlayerSpawner playerSpawner = new PlayerSpawner(_playerConfig, _spawnPoint.position);
            Entity player = playerSpawner.Create();
            Transform playerView = player.GetComponent<TransformComponent>().Transform;
            _enemySpawner = new EnemySpawner(_enemyConfig,  player, _spawnConfig);
            Entity camera = _cameraProvider.Entity;
            camera.SetComponent(new TransformComponent { Transform = _cameraProvider.gameObject.transform });
            camera.SetComponent(new FollowComponent { Target = playerView });

        }

        private void Update()
        {
            _enemySpawner.Spawn();
        }
    }
}
