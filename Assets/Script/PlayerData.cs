using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData:MonoBehaviour
{
    public InputField name;
    public Text welcome_Name;

    private void Start()
    {
        welcome_Name.text=PlayerPrefs.GetString("name");
    }
    public void clickSaveButton()
    {
        PlayerPrefs.SetString("name", name.text);
        string Name = PlayerPrefs.GetString("name");

        if (Name==null||Name=="")
        {
            Debug.Log("Null user name");
        }
        else if (Name!=null)
        {
            Debug.Log("Your name is "+ PlayerPrefs.GetString("name"));
            SceneManager.LoadScene("Home Scene");
        }
    }
    


    /* public string name;


     public PlayerData(string name)
     {
         this.name = name;
     }


     public override string ToString()
     {
         return $"{name}";
     }*/

}

