using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PatrolPoint2 : MonoBehaviour
{
    [SerializeField] private PatrolingPoint2 _patrolingPoint;
    
    private Transform[] _patrolingPoints;
    private Transform _patrolingNextPoint;
    private float _speed = 7f;
    private float _minResidual = .001f;
    private int _patrolingPointIndex;

    private void Start()
    {
        int patrolingPointLength = _patrolingPoint.transform.childCount;
        _patrolingPoints = new Transform[patrolingPointLength];

        for (int i = 0; i < patrolingPointLength; i++)
            _patrolingPoints[i] = _patrolingPoint.transform.GetChild(i);

        FindNearest();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _patrolingNextPoint.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _patrolingNextPoint.position) <= _minResidual)
        {
            _patrolingPointIndex++;
            _patrolingPointIndex %= _patrolingPoints.Length;
            _patrolingNextPoint = _patrolingPoints[_patrolingPointIndex];
        }
    }

    private void FindNearest()
    {
        float residualOfNextPoint = Vector3.Distance(_patrolingPoints[0].position, transform.position);
        _patrolingNextPoint = _patrolingPoints[0];

        for (int i = 1; i < _patrolingPoints.Length; i++)
        {
            float residual = Vector3.Distance(_patrolingPoints[i].position, transform.position);

            if (residual < residualOfNextPoint)
            {
                residualOfNextPoint = residual;
                _patrolingNextPoint = _patrolingPoints[i];
                _patrolingPointIndex = i;
            }
        }
    }
}

