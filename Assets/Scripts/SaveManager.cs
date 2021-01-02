using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private string filePath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        filePath = Application.persistentDataPath + "data.gamesave";

        LoadGame();
        SaveGame();
    }

    public void SaveGame()
    {
        using (var fs = new FileStream(filePath, FileMode.Create))
        {
            var bf = new BinaryFormatter();
            var save = new Save();
            save.Level = Player.CurrentScene == 0 ? 2 : Player.CurrentScene;
            save.Page = LevelContentScroll.SelectedPage;
            save.SliderSpeed = SliderUpperSpeed.Speed;
            bf.Serialize(fs, save);
        }
    }

    public void LoadGame()
    {
        if (!File.Exists(filePath))
        {
            return;
        }

        using (var fs = new FileStream(filePath, FileMode.Open))
        {
            var bf = new BinaryFormatter();

            var save = (Save)bf.Deserialize(fs);

            Player.CurrentScene = save.Level;
            LevelContentScroll.SelectedPage = save.Page;
            SliderUpperSpeed.Speed = save.SliderSpeed;
        }
    }

    [System.Serializable]
    public class Save
    {
        public int Level;
        public int Page;
        public float SliderSpeed;
    }
}
