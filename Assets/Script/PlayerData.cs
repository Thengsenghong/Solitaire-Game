using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerData
{

    public float score;
    public float minute;
    public string name;
    public PlayerData( float score, float minute, string name)
    {
   
        this.score = score;
        this.minute = minute;
        this.name = name;
    }

    public override string ToString()
    {
        return $"{score}, {minute},{name}";
    }

}

