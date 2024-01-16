using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _countDownDestroy = 10;

    private void Start()
    {
        StartCoroutine(DestroyObject());
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(_countDownDestroy);
        Destroy(gameObject);
    }
}
