using Invaders.Entities;
using UnityEngine;
using Zenject;

namespace Invaders.Di
{
    public class PlayerSpawner : MonoInstaller 
    {
        [SerializeField] private Player _player;
        [SerializeField] private Transform _spawnpoint;
        [SerializeField] private Transform _container;

        public override void InstallBindings() =>
            SpawnedPlayer = Spawn();

        public Player SpawnedPlayer { get; private set; }

        private Player Spawn() =>
            Container.InstantiatePrefabForComponent<Player>(_player, _spawnpoint.position, _spawnpoint.rotation, _container);
    }
}