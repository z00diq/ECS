using Assets._Project.Scripts.ECS.Damageable;
using Assets._Project.Scripts.ECS.Followable;
using Assets._Project.Scripts.ECS.Health;
using Assets._Project.Scripts.ECS.Enemy;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public class EnemySpawner
    {
        private readonly float _targerOffset = 1f;
        private readonly EnemyConfig _config;
        private readonly SpawnConfig _spawnConfig;
        private readonly Transform _player;

        private float _ellapsedTime;

        public EnemySpawner(EnemyConfig config, Entity player, SpawnConfig spawnConfig)
        {
            _config = config;
            _spawnConfig = spawnConfig;
            _player = player.GetComponent<TransformComponent>().Transform;
        }
       
        public void Spawn()
        {
            _ellapsedTime += Time.deltaTime;

            if (_ellapsedTime < _spawnConfig.SpawnTime)
                return;

            if (_player == null)
                return;

            Vector3 spawnPosition = GetRandomPosition();
            GameObject enemyView = GameObject.Instantiate(_config.Prefab, spawnPosition, Quaternion.identity);
            Entity enemy = enemyView.AddComponent<EnemyProvider>().Entity;

            enemy.SetComponent(new MoveComponent { Speed = _config.Speed, Position = enemyView.transform.position });
            enemy.SetComponent(new Damage { Value = _config.Damage, RealoadTime = _config.RealoadTime,IsReadyAttack = true,});
            enemy.SetComponent(new TransformComponent { Transform = enemyView.transform });
            enemy.SetComponent(new FollowComponent { Target = _player, TargetOffset = _targerOffset });
            enemy.SetComponent(new HealthComponent { Value = _config.Health });
            enemy.SetComponent(new Damagable());

            _ellapsedTime = 0;
        }

        private Vector3 GetRandomPosition()
        {
            Vector2 point = Random.insideUnitCircle.normalized;

            return new Vector3(point.x, 0f, point.y) * _spawnConfig.Distance + _player.position;
        }
    }
}
