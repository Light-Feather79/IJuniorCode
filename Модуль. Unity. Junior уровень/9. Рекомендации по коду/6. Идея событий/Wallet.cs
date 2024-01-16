using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;
    [SerializeField] private FileSaver _fileSaver;
    [SerializeField] private Shop _shop;

    public int Money { get; private set; }

    public void AddMoney(int amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount));

        Money += amount;

        _walletView.Display(Money);
        _fileSaver.SaveMoney(Money);
        _shop.OfferItems(Money);
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


public class EventExample : MonoBehaviour
{
    public event Action MoneyChanged;
    public event Action<int> MoneyAdded;
    public event Action<bool> EnemyKilled;
    public event Action<bool> DoorOpened;
    public event Action<bool> PaymentRecieved;
}