using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour
{
    public CardType Type;
    [HideInInspector]public int Value;
    public GameObject selectedSprite;
   
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

    public SpriteRenderer spriteRenderer;

    private void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        StartCoroutine(EnumStart());
    }

    IEnumerator EnumStart()
    {
       
        yield return new WaitForEndOfFrame();
        GameManager.instance.SelectRandomSlot();

        GameManager.instance.currentSlotToSpawn.AddCardToStack(this, GameManager.instance.currentSlotToSpawn.transform);
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

        if(targetSlot.stackedCards.Count == 0)
        {
            targetSlot.AddCardToStack(this, targetSlot.transform);

        }
        else
        {
            targetSlot.AddCardToStack(this, targetSlot.GetLastCardPosition());
        }
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
   
    public void DestroyMyCard()
    {
        switch (cardValue) 
        {
            case CardValue.k:
                switch (Type)
                {
                    case CardType.Heart:
                        for (int i = 0; i < MovesTracker.instance.goalCardsScriptList.Count; i++)
                        {
                            if(MovesTracker.instance.goalCardsScriptList[i].myCardType == GoalCard.CardType.K)
                            {
                                if(MovesTracker.instance.goalCardsScriptList[i].myCardSubType == GoalCard.CardSubType.Heart)
                                {
                                    MovesTracker.instance.goalCardsScriptList[i].DeductCardGoalNumber();
                                }
                            }
                        }

                        break;
                    case CardType.Club:
                        for (int i = 0; i < MovesTracker.instance.goalCardsScriptList.Count; i++)
                        {
                            if (MovesTracker.instance.goalCardsScriptList[i].myCardType == GoalCard.CardType.K)
                            {
                                if (MovesTracker.instance.goalCardsScriptList[i].myCardSubType == GoalCard.CardSubType.Club)
                                {
                                    MovesTracker.instance.goalCardsScriptList[i].DeductCardGoalNumber();
                                }
                            }
                        }

                        break;
                    case CardType.Diamond:
                        for (int i = 0; i < MovesTracker.instance.goalCardsScriptList.Count; i++)
                        {
                            if (MovesTracker.instance.goalCardsScriptList[i].myCardType == GoalCard.CardType.K)
                            {
                                if (MovesTracker.instance.goalCardsScriptList[i].myCardSubType == GoalCard.CardSubType.Diamond)
                                {
                                    MovesTracker.instance.goalCardsScriptList[i].DeductCardGoalNumber();
                                }
                            }
                        }

                        break;
                    case CardType.Spade:
                        for (int i = 0; i < MovesTracker.instance.goalCardsScriptList.Count; i++)
                        {
                            if (MovesTracker.instance.goalCardsScriptList[i].myCardType == GoalCard.CardType.K)
                            {
                                if (MovesTracker.instance.goalCardsScriptList[i].myCardSubType == GoalCard.CardSubType.Spade)
                                {
                                    MovesTracker.instance.goalCardsScriptList[i].DeductCardGoalNumber();
                                }
                            }
                        }

                        break;
                }
                break;
            case CardValue.Q:
                switch (Type)
                {
                    case CardType.Heart:
                        for (int i = 0; i < MovesTracker.instance.goalCardsScriptList.Count; i++)
                        {
                            if (MovesTracker.instance.goalCardsScriptList[i].myCardType == GoalCard.CardType.Q)
                            {
                                if (MovesTracker.instance.goalCardsScriptList[i].myCardSubType == GoalCard.CardSubType.Heart)
                                {
                                    MovesTracker.instance.goalCardsScriptList[i].DeductCardGoalNumber();
                                }
                            }
                        }

                        break;
                    case CardType.Club:
                        for (int i = 0; i < MovesTracker.instance.goalCardsScriptList.Count; i++)
                        {
                            if (MovesTracker.instance.goalCardsScriptList[i].myCardType == GoalCard.CardType.Q)
                            {
                                if (MovesTracker.instance.goalCardsScriptList[i].myCardSubType == GoalCard.CardSubType.Club)
                                {
                                    MovesTracker.instance.goalCardsScriptList[i].DeductCardGoalNumber();
                                }
                            }
                        }

                        break;
                    case CardType.Diamond:
                        for (int i = 0; i < MovesTracker.instance.goalCardsScriptList.Count; i++)
                        {
                            if (MovesTracker.instance.goalCardsScriptList[i].myCardType == GoalCard.CardType.Q)
                            {
                                if (MovesTracker.instance.goalCardsScriptList[i].myCardSubType == GoalCard.CardSubType.Diamond)
                                {
                                    MovesTracker.instance.goalCardsScriptList[i].DeductCardGoalNumber();
                                }
                            }
                        }

                        break;
                    case CardType.Spade:
                        for (int i = 0; i < MovesTracker.instance.goalCardsScriptList.Count; i++)
                        {
                            if (MovesTracker.instance.goalCardsScriptList[i].myCardType == GoalCard.CardType.Q)
                            {
                                if (MovesTracker.instance.goalCardsScriptList[i].myCardSubType == GoalCard.CardSubType.Spade)
                                {
                                    MovesTracker.instance.goalCardsScriptList[i].DeductCardGoalNumber();
                                }
                            }
                        }

                        break;
                }
                break;
            case CardValue.J:
                switch (Type)
                {
                    case CardType.Heart:
                        for (int i = 0; i < MovesTracker.instance.goalCardsScriptList.Count; i++)
                        {
                            if (MovesTracker.instance.goalCardsScriptList[i].myCardType == GoalCard.CardType.J)
                            {
                                if (MovesTracker.instance.goalCardsScriptList[i].myCardSubType == GoalCard.CardSubType.Heart)
                                {
                                    MovesTracker.instance.goalCardsScriptList[i].DeductCardGoalNumber();
                                }
                            }
                        }

                        break;
                    case CardType.Club:
                        for (int i = 0; i < MovesTracker.instance.goalCardsScriptList.Count; i++)
                        {
                            if (MovesTracker.instance.goalCardsScriptList[i].myCardType == GoalCard.CardType.J)
                            {
                                if (MovesTracker.instance.goalCardsScriptList[i].myCardSubType == GoalCard.CardSubType.Club)
                                {
                                    MovesTracker.instance.goalCardsScriptList[i].DeductCardGoalNumber();
                                }
                            }
                        }

                        break;
                    case CardType.Diamond:
                        for (int i = 0; i < MovesTracker.instance.goalCardsScriptList.Count; i++)
                        {
                            if (MovesTracker.instance.goalCardsScriptList[i].myCardType == GoalCard.CardType.J)
                            {
                                if (MovesTracker.instance.goalCardsScriptList[i].myCardSubType == GoalCard.CardSubType.Diamond)
                                {
                                    MovesTracker.instance.goalCardsScriptList[i].DeductCardGoalNumber();
                                }
                            }
                        }

                        break;
                    case CardType.Spade:
                        for (int i = 0; i < MovesTracker.instance.goalCardsScriptList.Count; i++)
                        {
                            if (MovesTracker.instance.goalCardsScriptList[i].myCardType == GoalCard.CardType.J)
                            {
                                if (MovesTracker.instance.goalCardsScriptList[i].myCardSubType == GoalCard.CardSubType.Spade)
                                {
                                    MovesTracker.instance.goalCardsScriptList[i].DeductCardGoalNumber();
                                }
                            }
                        }

                        break;
                }
                break;
        }
    }
}
