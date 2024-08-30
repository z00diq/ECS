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

        public void Create()
        {
            GameObject playerView = GameObject.Instantiate(_config.Prefab, _spawnPoint, Quaternion.identity);
            Entity player = World.Default.CreateEntity();
            player.AddComponent<MoveComponent>();
            player.SetComponent(new MoveComponent { Position = playerView.transform.position, Speed = _config.Speed});
            player.SetComponent(new InputComponent());
            player.SetComponent(new TransformComponent { Transform = playerView.transform });
            player.SetComponent(new RotationComponent());

        }
    }
}
