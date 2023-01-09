using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData:MonoBehaviour
{
    public InputField name1;
 
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
    }
    


    /* public string name1;


     public PlayerData(string name1)
     {
         this.name1 = name1;
     }


     public override string ToString()
     {
         return $"{name1}";
     }*/

}

