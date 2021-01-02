using UnityEngine;
public class VertikalCube : MonoBehaviour
{
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    private float _verticalMove;
    private Rigidbody _rigidbody;
    private void Start()
    {
        ValidateSpeed();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _verticalMove = Application.platform == RuntimePlatform.Android ? Input.acceleration.y :
                                                                          Input.GetAxis("Vertical");
       
        _rigidbody.velocity = new Vector3(0f, 0f, Mathf.Clamp(_verticalMove, _minSpeed, _maxSpeed) * SliderUpperSpeed.Speed); 
    }
    private void ValidateSpeed()
    {
        _minSpeed = _minSpeed >= _maxSpeed ? _maxSpeed : _minSpeed;
        _maxSpeed = _maxSpeed <= _minSpeed ? _minSpeed : _maxSpeed;
    }
}
