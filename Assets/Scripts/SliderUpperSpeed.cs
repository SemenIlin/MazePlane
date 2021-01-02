using UnityEngine;
using UnityEngine.UI;

public class SliderUpperSpeed : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    public void Start()
    {
        _slider.value = Speed;
    }
    public static float Speed { get; set; }

    public void SetSpeed()
    {
        Speed = _slider.value;
    }
}
