using UnityEngine;

public class AmbientSoundZone : MonoBehaviour
{
    [SerializeField] private AudioCkip _clip;
    [SerializeField] private AmbientSound _ambientSound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<AmbientListener>() == false)
            return;

        _ambientSound.SetAmbient(_clip);
    }
}