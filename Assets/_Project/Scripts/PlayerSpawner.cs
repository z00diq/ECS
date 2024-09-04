using Assets._Project.Scripts.ECS.Damageable;
using Assets._Project.Scripts.ECS.Health;
using Assets._Project.Scripts.ECS.Player;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets._Project.Scripts
{
    public class PlayerSpawner
    {
        private readonly PlayerConfig _config;
        private readonly Vector3 _spawnPoint = Vector3.zero;

        public PlayerSpawner(PlayerConfig config, Vector3 spawnPoint)
        {
            _config = config;
            _spawnPoint = spawnPoint;
        }

        public Entity Create()
        {
            TransformProvider playerView = Object.Instantiate(_config.Prefab, _spawnPoint, Quaternion.identity);
            Entity player = playerView.Entity;
            player.SetComponent(new MoveComponent { Position = playerView.transform.position, Speed = _config.Speed});
            player.SetComponent(new InputComponent());
            player.SetComponent(new RotationComponent());
            player.SetComponent(new PlayerMarker());
            player.SetComponent(new HealthComponent { Value = _config.Health });
            player.SetComponent(new Damage());

            return player;
        }
    }
}
