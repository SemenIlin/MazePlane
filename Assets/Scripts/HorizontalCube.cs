using UnityEngine;

public class HorizontalCube : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _horizontalMove;
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _horizontalMove = Application.platform == RuntimePlatform.Android ? Input.acceleration.x :
                                                                            Input.GetAxis("Horizontal");
        
        _rigidbody.velocity += new Vector3(_horizontalMove * _speed, 0f, 0f);
    }
}
