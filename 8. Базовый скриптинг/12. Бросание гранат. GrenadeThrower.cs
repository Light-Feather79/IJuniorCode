using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GrenadeThrower : MonoBehaviour
{
    [SerializeField] private float _throwForce;
    [SerializeField] private Grenade _grenadePrefab;
    [SerializeField] private Transform _throwPoint;

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
            Instantiate(_grenadePrefab, _throwPoint.position, _throwPoint.rotation).Throw(_throwPoint.forward * _throwForce);
    }
}

