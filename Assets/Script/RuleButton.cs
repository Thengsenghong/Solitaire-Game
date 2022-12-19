using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleButton : MonoBehaviour
{





    private void Start()
    {
        transform.localScale = Vector2.zero;
    }


    public void Open()
    {
        transform.LeanScale(Vector2.one, 0.5f);
    }
    public void Close()
    {
        transform.LeanScale(Vector2.zero, 1f).setEaseInBack();
    }

}
