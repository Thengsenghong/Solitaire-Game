using UnityEngine;
using static GetScoreAndShowScore;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class JSONSaving : MonoBehaviour
{
    //private PlayerData playerData;
    /*  private string path = "";
      private string persistenPath = "";*/
    //private RuleButton ruleButton;

    /* public InputField name1;
     public void clickSaveButton()
     {
         PlayerPrefs.SetString("name1", name1.text);
         string Name = PlayerPrefs.GetString("name1");

         if (Name==null||Name=="")
         {
             Debug.Log("Null user name1");
         }
         else if (Name!=null)
         {
             Debug.Log("Your name1 is "+ PlayerPrefs.GetString("name1"));
             SceneManager.LoadScene("Home Scene");
         }
     }*/


    /*  private void CreatePlayerData()
      {
          *//*  playerData = new PlayerData[2];
            playerData[0] = new PlayerData(11, 22, "ss");
            playerData[1] = new PlayerData(12, 33, "sw");*//*
      }

      private void SetPaths()
      {
          path = Application.dataPath + Path.AltDirectorySeparatorChar + "SaveData.json";

          persistenPath = Application.persistentDataPath + Path.AltDirectorySeparatorChar + "SaveData.json";
      }*/
    // Update is called once per frame


    /*  public void SaveData()
      {
          string savePath = persistenPath;

          Debug.Log("Saving Data at" + savePath);
          string json = JsonUtility.ToJson(playerData);
          Debug.Log(json);
          using StreamWriter writer = new StreamWriter(savePath);
          writer.Write(json);
          *//*  for (int i = 0; i < playerData.Length; i++)
            {

            }*//*
      }

      public void LoadData()
      {
          using StreamReader reader = new StreamReader(persistenPath);
          string json = reader.ReadToEnd();
          PlayerData data = JsonUtility.FromJson<PlayerData>(json);
          Debug.Log(data.ToString());
          *//*txtBoxName.text= data.ToString();*//*


       }*/

    public void ResetSavedGame()
    {
        PlayerPrefs.DeleteKey("name1");
        SceneManager.LoadScene("Login Scene");

    }
    public Text txtScore;
    public Text txtMinute;
    public Text txtSecond;
    public Text txtName;
    public async void ShowScoreButton()
    {
        var data = await HttpClientHelper.GetScore();
        var sorted = data.OrderByDescending(x => x.Score).ToList();

        var (name, score, minute, second)=("", "", "", "");
        if (sorted.Any())
        {
            /* sorted.ForEach(x =>                      //to get all row 
             {
                 name1+=x.Name+"\n\n";
                 score+=string.Format("{0:00}", x.Score)+"\n\n";
                 minute+= string.Format("{0:000}", x.Minute+":")+"\n\n";
                 second+= string.Format("{0:00}", x.Second)+"\n\n";
             });*/


            for (var i = 0; i<=9; i++)
            {
                var x = sorted[i];
                name+=x.Name+"\n\n";
                score+=string.Format("{0:00}", x.Score)+"\n\n";
                minute+= string.Format("{0:000}", x.Minute+":")+"\n\n";
                second+= string.Format("{0:00}", x.Second)+"\n\n";
            }

        }

        txtName.text = name;
        txtScore.text= score;
        txtMinute.text= minute;
        txtSecond.text= second;
    }
    public void Exit()
    {
        Application.Quit();
    }
     public void GotoPlayScene()
    {
        SceneManager.LoadScene(1);
    }
}
