using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class JSONSaving : MonoBehaviour
{
    private PlayerData playerData;
    private string path = "";
    private string persistenPath = "";

    // Start is called before the first frame update
    void Start()
    {
        CreatePlayerData();
        SetPaths();
    }

    private void CreatePlayerData()
    {
        playerData = new PlayerData("Trey", 500, 20);
    }

    private void SetPaths()
    {
        path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

        persistenPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
    }
    // Update is called once per frame
    void Update()
    {
      
    }

    public void SaveData()
    {
        string savePath = path;

        Debug.Log("Saving Data at" + savePath);
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);

        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
    }

    public void LoadData()
    {
        using StreamReader reader = new StreamReader(path);
        string json = reader.ReadToEnd();

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
    }
}
