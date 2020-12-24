using UnityEngine;

public class VertikalCube : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _verticalMove;
    private Rigidbody _rigidbody;
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _verticalMove = Application.platform == RuntimePlatform.Android ? Input.acceleration.y :
                                                                          Input.GetAxis("Vertical");
       
        _rigidbody.velocity += new Vector3(0f, 0f, _verticalMove * _speed);
    }
}
