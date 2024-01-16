using UnityEngine;

public class ChestOpenTrigger : MonoBehaviour
{
    [SerializeField] private Chest _chest;

    private bool _isOpened = false;
    private bool _hasOpener;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ChestOpener>())
            _hasOpener = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ChestOpener>())
            _hasOpener = false;
    }

    private void Update()
    {
        if (_isOpened)
            return;

        if (_hasOpener && Input.GetKeyDown(KeyCode.E))
        {
            _chest.Open();
            _isOpened = true;
        }
    }
}