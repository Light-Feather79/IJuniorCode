using UnityEngine;

public class WalletView : MonoBehaviour
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