using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner2 : MonoBehaviour
{
    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private Transform _spawnPoint;
    
    private SpawnPoint2[] _spawns;

    private void Start()
    {
        int childCount = _spawnPoint.transform.childCount;
        _spawns = new SpawnPoint2[childCount];

        for (int i = 0; i < childCount; i++)
            _spawns[i] = _spawnPoint.transform.GetChild(i).GetComponent<SpawnPoint2>();

        InvokeRepeating(nameof(SpawnEnemy), _repeatRate, _repeatRate);
    }

    private void SpawnEnemy()
    {
        _spawns[Random.Range(0, _spawns.Length)].InstantiateEnemy();
    }
}
