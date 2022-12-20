using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateSprite : MonoBehaviour
{
    public Sprite cardFace;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private Selectable selectable;
    private Solitaire solitaire;
    private UserInput userInput;
    private bool coroutineAllowed, facedUp;

    // Start is called before the first frame update
    void Start()
    {
        List<string> deck = Solitaire.GenerateDeck();
        solitaire = FindObjectOfType<Solitaire>();
        userInput = FindObjectOfType<UserInput>();
        int i = 0;
        foreach (string card in deck)
        {
            if (this.name == card)
            {
                cardFace = solitaire.cardFaces[i];
                break;
            }
            i++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        selectable = GetComponent<Selectable>();
        coroutineAllowed = true;
        facedUp = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (selectable.faceUp == true)
        {
            if (coroutineAllowed)
            {
                if (spriteRenderer.sprite == cardBack)
                {
                    AudioManager.Instance.PlaySFX("Open");
                    StartCoroutine(RotateCard());
                }
            }
            //  spriteRenderer.sprite = cardFace;
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }
        if (userInput.slot1)
            if (name == userInput.slot1.name)
            {
                spriteRenderer.color = solitaire.selectedColor;
            }
            else
            {
                spriteRenderer.color = Color.white;
            }
    }
    private IEnumerator RotateCard()
    {
        coroutineAllowed = false;
        if (!facedUp)
        {
            for (float i = 180f; i <= 360f; i += 10f) /*(float i = 360f; i >= 180f; i -= 10f)*/
            {
                transform.rotation = Quaternion.Euler(0f, i, 0f);
                if (i == 270f)
                {
                   
                    spriteRenderer.sprite = cardFace;
                }
                yield return new WaitForSeconds(0.01f);
            }
        }

        coroutineAllowed = true;
    }
}
