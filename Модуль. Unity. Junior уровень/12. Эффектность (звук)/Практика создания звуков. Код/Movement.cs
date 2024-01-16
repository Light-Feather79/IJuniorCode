using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private FootStepsSound _stepsSounds;
    [SerializeField] private float _stepDistance;

    private float _coveredDistance;

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float rotation = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * rotation * _rotationSpeed * Time.deltaTime);
    }

    private void Move()
    {
        float direction = Input.GetAxis("Vertical");

        if (direction == 0f)
        {
            _coveredDistance = 0f;
            return;
        }

        float distance = _moveSpeed * direction * Time.deltaTime;
        _coveredDistance += Mathf.Abs(distance);
        transform.Translate(Vector3.forward * distance);

        if(_coveredDistance >= _stepDistance)
        {
            _coveredDistance -= _stepDistance;
            _stepsSounds.Play();
        }
    }
}