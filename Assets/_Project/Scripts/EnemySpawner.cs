using Assets._Project.Scripts.ECS.Followable;
using Assets._Project.Scripts.ECS.Health;
using Scellecs.Morpeh;
using UnityEngine;
using AttackComponent = Assets._Project.Scripts.ECS.Attack.Attack;

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
            TransformProvider enemyView = Object.Instantiate(_config.Prefab, spawnPosition, Quaternion.identity);
            Entity enemy = enemyView.Entity;

            enemy.SetComponent(new MoveComponent { Speed = _config.Speed, Position = enemyView.transform.position });
            enemy.SetComponent(new AttackComponent { Damage = _config.Damage, RealoadTime = _config.RealoadTime,IsReadyToAttack = true});
            enemy.SetComponent(new FollowComponent { Target = _player, TargetOffset = _targerOffset });
            enemy.SetComponent(new HealthComponent { Value = _config.Health });
            
            _ellapsedTime = 0;
        }

        private Vector3 GetRandomPosition()
        {
            Vector2 point = Random.insideUnitCircle.normalized;

            return new Vector3(point.x, 0f, point.y) * _spawnConfig.Distance + _player.position;
        }
    }
}
