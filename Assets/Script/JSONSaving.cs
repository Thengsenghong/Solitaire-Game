using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using static GetScoreAndShowScore;
using Unity.VisualScripting.Antlr3.Runtime;
using System.Linq;
using UnityEngine.UI;

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

        playerData = new PlayerData(11, 44, "wfc");


        /*  playerData = new PlayerData[2];
          playerData[0] = new PlayerData(11, 22, "ss");
          playerData[1] = new PlayerData(12, 33, "sw");*/

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
        string savePath = persistenPath;

        Debug.Log("Saving Data at" + savePath);
        string json = JsonUtility.ToJson(playerData);
        Debug.Log(json);
        using StreamWriter writer = new StreamWriter(savePath);
        writer.Write(json);
        /*  for (int i = 0; i < playerData.Length; i++)
          {

          }*/
    }

    public void LoadData()
    {
        using StreamReader reader = new StreamReader(persistenPath);
        string json = reader.ReadToEnd();
        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        Debug.Log(data.ToString());
        /*   for (int i = 0; i < playerData.Length; i++)
           {  
           }*/
    }
    public Text txtScore;
    public Text txtMinute;
    public Text txtSecond;
    public async void ShowScoreButton()
    {
        var data = await HttpClientHelper.GetScore();
        var (score, minute, second)=("", "", "");
        if (data.Any())
        {
            data.ForEach(x =>
            {
                score+=string.Format("{0:00}", x.Score)+"\n\n";
                minute+= string.Format("{0:000}", x.Minute+":")+"\n\n";
                second+= string.Format("{0:00}", x.Second)+"\n\n";
            });
        }
        txtScore.text= score;
        txtMinute.text= minute;
        txtSecond.text= second; 
    }
}
