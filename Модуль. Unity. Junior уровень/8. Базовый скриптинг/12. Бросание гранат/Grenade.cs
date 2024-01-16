using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grenade : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionDelay;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ParticleSystem _effect;

    private void Update()
    {
        if (_explosionDelay <= 0f)
            Explode();

        _explosionDelay -= Time.deltaTime;
    }

    public void Throw(Vector3 force) =>
        _rigidbody.AddForce(force);

    private void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (Collider hit in hits)
            if (hit.transform.TryGetComponent(out Block block))
                block.Destroy();

        Instantiate(_effect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
