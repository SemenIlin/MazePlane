using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private const int QUANTITY_NON_GAME_SCENES = 2;
    [SerializeField] private int _countLevelsOnPages;

    private int _levelComplete;
    public static ButtonController Instance { get; private set; }
    private void Start()
    {
        if (Instance == null)
            Instance = this;

        _levelComplete = PlayerPrefs.GetInt("LevelComplete");
    }
        public void QuitGame()
    {
        Application.Quit();
    }

    public void ContinueGame()
    {
        SaveManager.Instance.LoadGame();
        SceneManager.LoadScene(Player.CurrentScene);
    }

    public void OpenScene(int lvl1)
    {
        SceneManager.LoadScene(lvl1);
    }
    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Reset()
    {
        Player.CurrentScene = 2;
        LevelContentScroll.SelectedPage = 0;
        SaveManager.Instance.SaveGame();
        PlayerPrefs.DeleteAll();
        SaveManager.Instance.SaveGame();
    }

    public void IsEndGame()
    {
        if (LevelController.TOTAL_QUANTITY_SCENES == Player.CurrentScene)
            Invoke("LoadLevelScene", 1f);
        else
        {
            if (_levelComplete < Player.CurrentScene)
                PlayerPrefs.SetInt("LevelComplete", Player.CurrentScene - QUANTITY_NON_GAME_SCENES);
            if (PlayerPrefs.GetInt("LevelComplete") % _countLevelsOnPages == 0)
            {
                ++LevelContentScroll.SelectedPage;
            }

            Invoke("NextLevel", 1f); 
        }
    }

    private void NextLevel()
    {
        SceneManager.LoadScene(Player.CurrentScene);
    }

    private void LoadLevelScene()
    {
        SceneManager.LoadScene("LevelMenu");
    }
}
