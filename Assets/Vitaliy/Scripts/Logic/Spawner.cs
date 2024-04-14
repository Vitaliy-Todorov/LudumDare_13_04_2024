using System.Collections.Generic;
using Infrastructure;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] 
    private List<SpawnData> _spawnData;

    private EntityFactory _entityFactory;
    private AudioManager _audioManager;

    public void Construct(EntityFactory entityFactory, AudioManager audioManager)
    {
        _audioManager = audioManager;
        _entityFactory = entityFactory;
    }

    private void Awake()
    {
        foreach (SpawnData spawnData in _spawnData)
        {
            for (int i = 0; i < spawnData.Amount; i++)
            {
                int indexSpawnPoint = Random.Range(0, spawnData.SpawnPoints.Count);
                AudioSource audioSource = _entityFactory.CreateEnemy(spawnData.SpawnPoints[indexSpawnPoint].position, spawnData.Parent)
                    .GetComponentInChildren<AudioSource>();
                _audioManager.AddAudio(audioSource);
            }
        }
    }
}