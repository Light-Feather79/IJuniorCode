
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Money { get; private set; }

    public event Action AmountChanged;

    public void AddMoney(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        Money += amount;

        if (AmountChanged != null)
            AmountChanged.Invoke(); // or MoneyChanged?.Invoke();
    }

    public bool TrySpendMoney(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        bool isEnough = Money >= amount;

        if (isEnough)
            Money -= amount;

        return isEnough;
    }
}