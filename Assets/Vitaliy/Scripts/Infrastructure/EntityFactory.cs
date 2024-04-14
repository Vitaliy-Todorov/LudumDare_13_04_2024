using System;
using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;

namespace Infrastructure
{
    [Serializable]
    public class EntityFactory
    {
        [field: SerializeField]
        public Player Player { get; private set; }

        private StaticDataService _staticDataService;
        private DependencyInjection _container;


        public EntityFactory(DependencyInjection container, StaticDataService staticDataServes)
        {
            _container = container;
            _staticDataService = staticDataServes;
        }

        public void Construct(DependencyInjection container, StaticDataService staticDataServes)
        {
            _container = container;
            _staticDataService = staticDataServes;
        }

        public Player CreatePlayer(Vector3 position, CinemachineVirtualCamera camera)
        {
            Player = GameObject.Instantiate(_staticDataService
                    .GetEntityData(EEntity.Player).Prefab, position, Quaternion.identity)
                .GetComponent<Player>();
            camera.Follow = Player.transform;
            return Player;
        }

        public Enemy CreateEnemy(Vector3 position)
        {
            GameObject enemyGO = _staticDataService.GetEntityData(EEntity.Enemy).Prefab;
            Enemy enemy = GameObject.Instantiate(enemyGO, position, Quaternion.identity)
                    .GetComponent<Enemy>();
            enemy.Construct(_container);
            return enemy;
        }

        public Enemy CreateEnemy(Vector3 position, Transform parent)
        {
            GameObject enemyGO = _staticDataService.GetEntityData(EEntity.Enemy).Prefab;
            Enemy enemy = GameObject.Instantiate(enemyGO, position, Quaternion.identity, parent)
                .GetComponent<Enemy>();
            enemy.Construct(_container);
            return enemy;
        }
    }
}