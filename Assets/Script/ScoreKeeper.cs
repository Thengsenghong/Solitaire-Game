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
    private int minute = 0;
    private float time = 0;
    [SerializeField]
    private Text minutetxt, secondtxt;
    [SerializeField]
    private Text minutetxtEndScene, secondtxtEndScene;  

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
        time += Time.deltaTime;

        if (time > 59)
        {
            minute++;
            minutetxt.text = minute.ToString("00") + " : ";
            minutetxtEndScene.text = minute.ToString("00") + " : ";
            time = 0;
        
        }
        secondtxt.text = Mathf.Round(time).ToString("00");
        secondtxtEndScene.text = Mathf.Round(time).ToString("00");
    }
    public bool HasWon()
    {
        int i = 0;
        foreach (Selectable topstack in topStacks)
        {
            i += topstack.value;

        }
        if (i >= 2)
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
