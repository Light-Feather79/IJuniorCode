using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private float _speed = 10;
    [SerializeField] private float _countDownDestroy = 10;

    private EnemyType2 _type;
    private Transform _target;

    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }

    public void SetTarget(EnemyType2 type, Transform target)
    {
        _type = type;
        _target = target;
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(_countDownDestroy);
        Destroy(gameObject);
    }
}
