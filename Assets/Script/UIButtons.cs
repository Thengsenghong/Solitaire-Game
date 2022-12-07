using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public GameObject highScorePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayAgain()
    {
        highScorePanel.SetActive(false);
        ResetScene();
       
    }
    public void ResetScene()
    {
        /*   // find all the cards and remove them
           UpdateSprite[] cards = FindObjectsOfType<UpdateSprite>();
           foreach(UpdateSprite card in cards)
           {
               Destroy(card.gameObject);
           }
           // clear the top values
           ClearTopValues();

           // deal new cards
           FindObjectOfType<Solitaire>().PlayCards();*/
        SceneManager.LoadScene(1);
        
    }
    void ClearTopValues()
    {
        Selectable[] selectables = FindObjectsOfType<Selectable>();
        foreach (Selectable selectable in selectables)
        {
            if (selectable.CompareTag("Top"))
            {
                selectable.suit = null;
                selectable.value = 0;
            }
        }
    }
    public void ClearCard()
    {
        //clear card
        UpdateSprite[] cards = FindObjectsOfType<UpdateSprite>();
        foreach (UpdateSprite card in cards)
        {
            Destroy(card.gameObject);
        }
        //  clear card form top
        ClearTopValues();
    }
    public void GotoPlayScene()
    {
        SceneManager.LoadScene(1);
    }
    public void GotoHomeScene()
    {
        SceneManager.LoadScene(0);
    }
}
