using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData
{
    public string name;
    public float score;
    public float minute;

    public PlayerData(string name, float score, float minute)
    {
        this.name = name;
        this.score = score;
        this.minute = minute;
    }
  
  /*  public override string ToString()
    {
        return $"{name}, {score}, {minute}";
    }*/

}

