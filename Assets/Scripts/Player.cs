using UnityEngine;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    private const int TOTAL_QUANTITY_SCENES = 6;
    [SerializeField] private float _speed;

    private float _verticalMove;
    private Vector3 _moveDirection;
    private Rigidbody _rigidbody;
    public static int CurrentScene { get; set; }
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _verticalMove = Application.platform == RuntimePlatform.Android ? Input.acceleration.y :
                                                                          Input.GetAxis("Vertical");
        
        _moveDirection = new Vector3(0, 0, _verticalMove * _speed);
        _rigidbody.velocity += _moveDirection;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            if (SceneManager.GetActiveScene().buildIndex + 1 == TOTAL_QUANTITY_SCENES)
            {
                SceneManager.LoadScene(0);
                return;
            }

            CurrentScene = SceneManager.GetActiveScene().buildIndex + 1;
            ButtonController.Instance.IsEndGame();
            SaveManager.Instance.SaveGame();
        }
    }
}
