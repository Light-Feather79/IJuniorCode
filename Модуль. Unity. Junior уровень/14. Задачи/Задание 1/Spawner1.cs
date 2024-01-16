using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner1 : MonoBehaviour
{
    [SerializeField] private Enemy1 _enemyPrefab;
    [SerializeField] private SpawnPoint1 _spawnPoint;
    [SerializeField] private float _randomAngle = 360f;
    [SerializeField] private float _repeatRate = 1f;
    [SerializeField] private float _positionAlignment = 1.5f;

    private Transform[] _spawns;

    private void Start()
    {
        int childCount = _spawnPoint.transform.childCount;
        _spawns = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
            _spawns[i] = _spawnPoint.transform.GetChild(i);

        InvokeRepeating(nameof(SpawnEnemy), _repeatRate, _repeatRate);
    }

    private void SpawnEnemy()
    {
        Quaternion rotationOffset = Quaternion.AngleAxis(Random.value * _randomAngle, Vector3.up);
        Transform randomSpawnPoint = _spawns[Random.Range(0, _spawns.Length)];
        Vector3 spawnPosition = randomSpawnPoint.position + Vector3.up * _positionAlignment;

        Instantiate(_enemyPrefab, spawnPosition, rotationOffset);
    }
}
