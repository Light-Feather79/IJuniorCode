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