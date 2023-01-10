using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
 
    public InputField nameAddToPlayerPref;
   
  
   
    public void ClickSaveButton()
    {
        PlayerPrefs.SetString("nameAddToPlayerPref", nameAddToPlayerPref.text);
        string Name = PlayerPrefs.GetString("nameAddToPlayerPref");

        if (Name==null||Name=="")
        {
            Debug.Log("Null user nameAddToPlayerPref");
        }
        else if (Name!=null)
        {
            Debug.Log("Your nameAddToPlayerPref is "+ PlayerPrefs.GetString("nameAddToPlayerPref"));
            SceneManager.LoadScene("Home Scene");
        }
    }
    #region BoardClick
    public void Board1Click()
    {
        PlayerPrefs.SetString("board1", "clicked");
        PlayerPrefs.SetString("board2", "null");
        PlayerPrefs.SetString("board3", "null");
        PlayerPrefs.SetString("board4", "null");
        Debug.Log(PlayerPrefs.GetString("board1"));
        Debug.Log(PlayerPrefs.GetString("board2"));
        Debug.Log(PlayerPrefs.GetString("board3"));
        Debug.Log(PlayerPrefs.GetString("board4"));
    }
    public void Board2Click()
    {
        PlayerPrefs.SetString("board1", "null");
        PlayerPrefs.SetString("board2", "clicked");
        PlayerPrefs.SetString("board3", "null");
        PlayerPrefs.SetString("board4", "null");
        Debug.Log(PlayerPrefs.GetString("board1"));
        Debug.Log(PlayerPrefs.GetString("board2"));
        Debug.Log(PlayerPrefs.GetString("board3"));
        Debug.Log(PlayerPrefs.GetString("board4"));
    }
    public void Board3Click()
    {
        PlayerPrefs.SetString("board1", "null");
        PlayerPrefs.SetString("board2", "null");
        PlayerPrefs.SetString("board3", "clicked");
        PlayerPrefs.SetString("board4", "null");
        Debug.Log(PlayerPrefs.GetString("board1"));
        Debug.Log(PlayerPrefs.GetString("board2"));
        Debug.Log(PlayerPrefs.GetString("board3"));
        Debug.Log(PlayerPrefs.GetString("board4"));
    }
    public void Board4Click()
    {
        PlayerPrefs.SetString("board1", "null");
        PlayerPrefs.SetString("board2", "null");
        PlayerPrefs.SetString("board3", "null");
        PlayerPrefs.SetString("board4", "clicked");
        Debug.Log(PlayerPrefs.GetString("board1"));
        Debug.Log(PlayerPrefs.GetString("board2"));
        Debug.Log(PlayerPrefs.GetString("board3"));
        Debug.Log(PlayerPrefs.GetString("board4"));
    }
    #endregion

    /* public string nameAddToPlayerPref;


     public PlayerData(string nameAddToPlayerPref)
     {
         this.nameAddToPlayerPref = nameAddToPlayerPref;
     }


     public override string ToString()
     {
         return $"{nameAddToPlayerPref}";
     }*/

}

