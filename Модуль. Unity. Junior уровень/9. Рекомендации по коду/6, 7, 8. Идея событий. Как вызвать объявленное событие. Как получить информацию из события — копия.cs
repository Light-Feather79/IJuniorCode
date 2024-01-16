using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wallet1 : MonoBehaviour // Лекция 6. Идея событий
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


public class EventExample : MonoBehaviour // Лекция 6. Идея событий
{
    public event Action MoneyChanged;
    public event Action<int> MoneyAdded;
    public event Action<bool> EnemyKilled;
    public event Action<bool> DoorOpened;
    public event Action<bool> PaymentRecieved;
}

public class Wallet2 : MonoBehaviour //Лекция 7. Как вызвать объявленное событие
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

public class WalletView : MonoBehaviour //Лекция 8. Как получить информацию из события
{
    [SerializeField] private TextMeshProUGUI _amountView;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        _wallet.AmountChanged += DisplayAmount;
    }

    private void OnDisable()
    {
        _wallet.AmountChanged -= DisplayAmount;
    }

    public void DisplayAmount()
    {
        float amount = _wallet.Money;
        _amountViewView.text = amount.ToString();
    }
}