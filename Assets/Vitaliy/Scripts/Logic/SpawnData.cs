using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnData
{
    [SerializeField] 
    private int _amount;
    [SerializeField] 
    private GameObject _prefab;
    [SerializeField] 
    private List<Transform> _spawnPoints;
    [SerializeField] 
    private Transform _parent;

    public GameObject Prefab => _prefab;

    public List<Transform> SpawnPoints => _spawnPoints;

    public int Amount => _amount;

    public Transform Parent => _parent;
}