
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData:MonoBehaviour
{
    public InputField nameAddToPlayerPref;
 
    public void clickSaveButton()
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

