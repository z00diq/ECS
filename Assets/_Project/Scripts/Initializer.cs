using Assets._Project.Scripts.ECS.Camera;
using Assets._Project.Scripts.ECS.Damageable;
using Assets._Project.Scripts.ECS.Followable;
using Assets._Project.Scripts.ECS.OnTimerDestroy;
using Assets._Project.Scripts.ECS.Reaload;
using Assets._Project.Scripts.ECS.Shooting;
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
            InitializeWorld();

            PlayerSpawner playerSpawner = new PlayerSpawner(_playerConfig, _spawnPoint.position);
            Entity player = playerSpawner.Create();
            Transform playerView = player.GetComponent<TransformComponent>().Transform;
            _enemySpawner = new EnemySpawner(_enemyConfig, player, _spawnConfig);
            Entity camera = _cameraProvider.Entity;
            camera.SetComponent(new FollowComponent { Target = playerView });
        }

        private void Update()
        {
            _enemySpawner.Spawn();
        }

        private void InitializeWorld()
        {
            World world = World.Default;
            SystemsGroup systemGroup = world.CreateSystemsGroup();
            systemGroup.AddSystem(new InputSystem());
            systemGroup.AddSystem(new InputProviderSystem());
            systemGroup.AddSystem(new FollowSystem());
            systemGroup.AddSystem(new CameraFollowSystem());
            systemGroup.AddSystem(new MoveSystem());
            systemGroup.AddSystem(new RotationSystem());
            systemGroup.AddSystem(new ShootingSystem());
            systemGroup.AddSystem(new ReloadSystem());
            systemGroup.AddSystem(new DamageSystem());
            systemGroup.AddSystem(new DestroySystem());
            systemGroup.AddSystem(new RenderSystem());
            world.AddSystemsGroup(0, systemGroup);
        }
    }
}
