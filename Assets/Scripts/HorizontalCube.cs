using UnityEngine;

public class HorizontalCube : MonoBehaviour
{
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    private float _horizontalMove;
    private Rigidbody _rigidbody;
    private void Start()
    {
        ValidateSpeed();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _horizontalMove = Application.platform == RuntimePlatform.Android ? Input.acceleration.x :
                                                                            Input.GetAxis("Horizontal");
        
        _rigidbody.velocity = new Vector3(Mathf.Clamp(_horizontalMove, _minSpeed, _maxSpeed) * SliderUpperSpeed.Speed, 0f, 0f);
    }
    private void ValidateSpeed()
    {
        _minSpeed = _minSpeed >= _maxSpeed ? _maxSpeed : _minSpeed;
        _maxSpeed = _maxSpeed <= _minSpeed ? _minSpeed : _maxSpeed;
    }
}
