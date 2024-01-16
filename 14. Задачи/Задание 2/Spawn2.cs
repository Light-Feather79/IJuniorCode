using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint2 : MonoBehaviour
{
    [SerializeField] private EnemyType2 _enemyType;
    [SerializeField] private Transform _enemyTarget;
    [SerializeField] private Enemy2 _enemyPrefab;
    
    private float _positionAlignment = 1.5f;

    public void InstantiateEnemy()
    {
        Vector3 spawnPosition = transform.position + Vector3.up * _positionAlignment;

        Instantiate(_enemyPrefab, spawnPosition, Quaternion.identity).SetTarget(_enemyType, _enemyTarget);
    }
}
