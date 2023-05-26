using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Transform stackParent;  // Parent transform for the stacked cards
    public float cardSpacing;  // Spacing between stacked cards

    public List<CardBase> stackedCards = new List<CardBase>();

    public int startingSortingOrder = 0;
    private int sortingOrderIncrement = 1;

    
    private void Start()
    {
        stackParent = this.transform;
    }

    private void Update()
    {
        if (!GameManager.instance.hasGameStarted)
        {
            return;
        }

        // Check if there are cards in the stack
        if (stackedCards.Count > 0)
        {
            // Get the last card in the stackedCards list
            CardBase lastCard = stackedCards[stackedCards.Count - 1];

            // Check if the last card is face down
            if (!lastCard.IsFaceUp)
            {
                // Flip the last card face up
                lastCard.FlipFaceUp();
            }
        }
    }
    public void AddCardToStack(CardBase card)
    {
       
        // Add the card to the stacked cards list
        stackedCards.Add(card);

        // Update the card's position in the stack
        UpdateCardPosition(card);

        if (!card.IsFaceUp)
        {
            return;
        }


        DestroyConsecutiveDuplicateCards();
        DestroyConsecutiveSequentialCards();
    }

    public void RemoveCardFromStack(CardBase card)
    {
        if (!card.IsFaceUp)
        {
            return;
        }

        // Remove the card from the stacked cards list
        stackedCards.Remove(card);

        // Update the positions of remaining cards in the stack
        foreach (CardBase stackedCard in stackedCards)
        {
            UpdateCardPosition(stackedCard);
        }
    }

    private void UpdateCardPosition(CardBase card)
    {

        // Calculate the position of the card in the stack based on its index
        int cardIndex = stackedCards.IndexOf(card);
        Vector3 newPosition = transform.position + Vector3.down * cardSpacing * cardIndex;

        // Set the card's new position
        card.transform.position = newPosition;

        // Update the sorting order based on the card's position in the stack
        int sortingOrder = startingSortingOrder + (sortingOrderIncrement * cardIndex);
        SpriteRenderer spriteRenderer = card.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = sortingOrder;
        }
    }

    public void GetlastCard()
    {
        int last = stackedCards.Count - 1;
        stackedCards[last].SelectCard();
    }

    private void DestroyConsecutiveDuplicateCards()
    {
        int count = stackedCards.Count;
        if (count >= 3)
        {
            for (int i = count - 1; i >= 2; i--)
            {
                if(!stackedCards[i - 1].GetComponent<CardBase>().IsFaceUp)
                {
                    return;
                }

                if (!stackedCards[i - 2].GetComponent<CardBase>().IsFaceUp)
                {
                    return;
                }

                if (stackedCards[i].GetComponent<CardBase>().Value == stackedCards[i - 1].GetComponent<CardBase>().Value &&
                    stackedCards[i].GetComponent<CardBase>().Value == stackedCards[i - 2].GetComponent<CardBase>().Value)
                {
                    Destroy(stackedCards[i].gameObject);
                    Destroy(stackedCards[i - 1].gameObject);
                    Destroy(stackedCards[i - 2].gameObject);
                    stackedCards.RemoveAt(i);
                    stackedCards.RemoveAt(i - 1);
                    stackedCards.RemoveAt(i - 2);
                    break;
                }
            }
        }
    }


    private void DestroyConsecutiveSequentialCards()
    {
        int count = stackedCards.Count;
        if (count >= 3)
        {
            for (int i = count - 1; i >= 2; i--)
            {
                CardBase currentCard = stackedCards[i].GetComponent<CardBase>();
                CardBase previousCard1 = stackedCards[i - 1].GetComponent<CardBase>();
                CardBase previousCard2 = stackedCards[i - 2].GetComponent<CardBase>();

                if (!previousCard1.IsFaceUp)
                {
                    break;
                }

                if (!previousCard2.IsFaceUp)
                {
                    break;
                }

                if (currentCard.Type == previousCard1.Type && previousCard1.Type == previousCard2.Type &&
                    currentCard.Value == previousCard1.Value + 1 && previousCard1.Value == previousCard2.Value + 1)
                {
                    Destroy(stackedCards[i].gameObject);
                    Destroy(stackedCards[i - 1].gameObject);
                    Destroy(stackedCards[i - 2].gameObject);
                    stackedCards.RemoveAt(i);
                    stackedCards.RemoveAt(i - 1);
                    stackedCards.RemoveAt(i - 2);
                    break;
                }
            }
        }
    }


}
