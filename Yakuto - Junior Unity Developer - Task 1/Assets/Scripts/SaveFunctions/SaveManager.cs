using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;

    private void Awake()
    {
        instance = this;
    }

    public void SaveGame(PlayerStats saveData)
    {
        string filePath = Path.Combine(Application.persistentDataPath, "save.dat");

        if (!File.Exists(filePath))
            File.Create(filePath);

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream dataStream = new FileStream(filePath, FileMode.OpenOrCreate);

        PlayerDataBase saveDataBase = new PlayerDataBase(saveData);

        formatter.Serialize(dataStream, saveDataBase);

        dataStream.Close();
    }

    public PlayerDataBase LoadGame()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "save.dat");

        if (!File.Exists(filePath))
            File.Create(filePath);

        try
        {
            BinaryFormatter converter = new BinaryFormatter();

            // File exists  
            FileStream dataStream = new FileStream(filePath, FileMode.Open);

            PlayerDataBase saveData = converter.Deserialize(dataStream) as PlayerDataBase;

            dataStream.Close();
            return saveData;
        }
        catch
        {
            // File does not exist
            Debug.LogError("Save file is not found in " + filePath);
            return null;
        }
    }
}
