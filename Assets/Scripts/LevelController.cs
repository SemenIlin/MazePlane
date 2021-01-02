using UnityEngine;
using UnityEngine.UI;


public class LevelController : MonoBehaviour
{
    public const int TOTAL_QUANTITY_SCENES = 21;

    [SerializeField] private Button[] _levels;

    private int _levelComplete;
    private void Start()
    {
        _levelComplete = PlayerPrefs.GetInt("LevelComplete");
        if (_levels == null || _levels.Length < 1)
            return;

        foreach (var level in _levels)
            level.interactable = false;

        _levels[0].interactable = true;
        
        for (var i = 0; i <= _levelComplete; ++i)
        {
            _levels[i].interactable = true;
        }        
    }
}
