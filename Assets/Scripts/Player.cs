using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;

    private float _verticalMove;
    private Rigidbody _rigidbody;
    public static int CurrentScene { get; set; }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 == LevelController.TOTAL_QUANTITY_SCENES)
            {
                SceneManager.LoadScene(0);
                return;
            }

            CurrentScene = SceneManager.GetActiveScene().buildIndex + 1;
            ButtonController.Instance.IsEndGame();
            SaveManager.Instance.SaveGame();
        }
    }
    private void ValidateSpeed()
    {
        _minSpeed = _minSpeed >= _maxSpeed ? _maxSpeed : _minSpeed;
        _maxSpeed = _maxSpeed <= _minSpeed ? _minSpeed : _maxSpeed;
    }
}
