using UnityEngine;

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