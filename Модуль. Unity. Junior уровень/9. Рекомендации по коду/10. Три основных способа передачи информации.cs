using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _baseSpeed;

    private RigidBody2D _rigidBody2D;
    private BonusTracker _bonusTracker;

    private void Awake()
    {
        _rigidBody2D = GetComponent<RigidBody2D>();
        _bonusTracker = GetComponent<BonusTracker>();
    }

    private void FixedUpdate()
    {
        float step = _baseSpeed * _bonusTracker.BonucCoefficient * Time.deltaTime;
        _rigidBody2D.velocity += Vector2.right * step;
    }
}

public class BonusTracker : MonoBehaviour
{
    private List<SpeedBonus> _bonuses = new List<SpeedBonus>();

    private float _bonusCoefficient;
    private float _defaultCoefficient = 1f;

    public float BonusCoefficient => _bonusCoefficient;

    private void Awake()
    {
        ResetCoefficient();
    }

    private void ResetCoefficient()
    {
        _bonusCoefficient = _defaultCoefficient;
    }

    private void CalculateBonuses()
    {
        ResetCoefficient();

        foreach (SpeedBonus bonus in _bonuses)
            _bonusCoefficient += bonus.ValuePercent;

        _bonusCoefficient = 1 + (_bonusCoefficient / 100);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out SpeedBonus bonus))
        {
            _bonuses.Add(bonus);
            CalculateBonuses;
        }
    }
}