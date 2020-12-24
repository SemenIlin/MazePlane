using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    private const int QUANTITY_NON_GAME_SCENES = 2;
    private const int QUANTITY_GAME_SCENES = 6;
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
        SceneManager.LoadScene(Player.CurrentScene);
        SaveManager.Instance.LoadGame();
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
        SaveManager.Instance.SaveGame();
        PlayerPrefs.DeleteAll();
    }

    public void IsEndGame()
    {
        if (QUANTITY_GAME_SCENES == Player.CurrentScene)
            Invoke("LoadLevelScene", 1f);
        else
        {
            if (_levelComplete < Player.CurrentScene)
                PlayerPrefs.SetInt("LevelComplete", Player.CurrentScene - QUANTITY_NON_GAME_SCENES);
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
