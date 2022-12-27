using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    public Selectable[] topStacks;
    public GameObject highScorePanel;
   

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
   
        if (HasWon())
        {
            Win();
            return;   //stop all function
        }
    }
    public bool HasWon()
    {
        int i = 0;
        foreach (Selectable topstack in topStacks)
        {
            i += topstack.value;

        }
        if (i >= 52)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void Win()
    {
        AudioManager.Instance.PlaySFX("Win");
        highScorePanel.SetActive(true);
    }
}
