using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Shoot();
    }

    private void Shoot()
    {
        Debug.Log("Shoot");
        _audioSource.Play();
    }
}