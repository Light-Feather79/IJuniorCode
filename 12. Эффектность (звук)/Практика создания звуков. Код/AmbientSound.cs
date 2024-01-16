using UnityEngine;

public class AmbientSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    public void SetAmbient(AudioClip clip)
    {
        _audioSource.clip = clip;
        _audioSource.Play();
    }
}