using UnityEngine;

namespace Assets._Project.Scripts
{
    public class Initializer:MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;
        [SerializeField] private Transform _spawnPoint;

        private void Start()
        {
            PlayerSpawner playerSpawner = new PlayerSpawner(_playerConfig, _spawnPoint.position);

            playerSpawner.Create();
        }
    }
}
