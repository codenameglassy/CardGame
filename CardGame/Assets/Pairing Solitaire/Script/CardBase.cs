using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour
{
    public CardType Type;
    [HideInInspector]public int Value;

   
    public bool IsFaceUp { get; private set; }
    // Enum to represent the card types
    public enum CardType
    {
        Heart,
        Diamond,
        Spade,
        Club
    }

    public enum CardValue
    {
        J,
        Q,
        k
    }
    public CardValue cardValue;
    public Sprite[] cardSpritesHeart;
    public Sprite[] cardSpritesDiamond;
    public Sprite[] cardSpritesSpade;
    public Sprite[] cardSpritesClub;
    public Sprite faceDown;
    int cardValueIndex;

    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(EnumStart());
    }

    IEnumerator EnumStart()
    {
       
        yield return new WaitForEndOfFrame();
        GameManager.instance.SelectRandomSlot();

        GameManager.instance.currentSlotToSpawn.AddCardToStack(this);
        ShowCard();

        yield return new WaitForEndOfFrame();

        FlipFaceDown();
    }

    private void FixedUpdate()
    {
       // ShowCard();
    }

    void SetType()
    {

        switch (Type)
        {
            case CardType.Heart:
                spriteRenderer.sprite = cardSpritesHeart[cardValueIndex - 11];
                break;

            case CardType.Diamond:
                spriteRenderer.sprite = cardSpritesDiamond[cardValueIndex - 11];
                break;

            case CardType.Spade:
                spriteRenderer.sprite = cardSpritesSpade[cardValueIndex - 11];
                break;

            case CardType.Club:
                spriteRenderer.sprite = cardSpritesClub[cardValueIndex - 11];
                break;
        }

    }

    void SetCard()
    {
        switch (cardValue)
        {
            case CardValue.J:
                cardValueIndex = 11;
                Value = 3;
                SetType();

                //spriteRenderer.sprite = cardSprites[0];
                break;

            case CardValue.Q:
                cardValueIndex = 12;
                Value = 2;
                SetType();

                // spriteRenderer.sprite = cardSprites[1];
                break;

            case CardValue.k:
                cardValueIndex = 13;
                Value = 1;
                SetType();

                //  spriteRenderer.sprite = cardSprites[2];
                break;
        }
    }
    private void ShowCard()
    {

        SetCard();


    }
    public void HideCard()
    {
       // spriteRenderer.sprite = cardSprites[3];
    }

    public void SelectCard()
    {
        GameManager.instance.selectedCard = this;
    }

    public void MoveCard(Slot mySlot,Slot targetSlot)
    {
        if (!IsFaceUp)
        {
            return;
        }
        mySlot.RemoveCardFromStack(this);
        targetSlot.AddCardToStack(this);
        FindObjectOfType<MovesTracker>().DeductMove();
    }

    // Method to flip the card face-up
    public void FlipFaceUp()
    {
        IsFaceUp = true;
        ShowCard();
        // Enable card functionality here
    }

    // Method to flip the card face-down
    public void FlipFaceDown()
    {
        IsFaceUp = false;
        spriteRenderer.sprite = faceDown;

        // Disable card functionality here
    }
   
}
