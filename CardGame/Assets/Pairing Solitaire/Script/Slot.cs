using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Slot : MonoBehaviour
{
    private Transform stackParent;  // Parent transform for the stacked cards
    public float cardSpacing;  // Spacing between stacked cards

    public List<CardBase> stackedCards = new List<CardBase>();

    public int startingSortingOrder = 0;
    private int sortingOrderIncrement = 1;
    public GameObject GameOver;
    public GameObject CardEffect;
    
    private void Start()
    {
        stackParent = this.transform;
        GameOver.SetActive(false);
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
        else
        {
            // Check if all slots are empty
            bool allSlotsEmpty = CheckAllSlotsEmpty();
            if (allSlotsEmpty)
            {
                // Call the game over view appearance method
                GameOver.SetActive(true);
            }
        }



    }
    private bool CheckAllSlotsEmpty()
    {
        // Iterate through all Slot objects
        Slot[] slots = FindObjectsOfType<Slot>();
        foreach (Slot slot in slots)
        {
            // Check if the slot has any stacked cards
            if (slot.stackedCards.Count > 0)
            {
                GameOver.SetActive(false);
                return false;
               // Slot is not empty
            }
        }
        return true; // All slots are empty
    }

    public void AddCardToStack(CardBase card, Transform lastCardPos)
    {
        StartCoroutine(EnumAddCardToStack(card, lastCardPos));
      
    }

    IEnumerator EnumAddCardToStack(CardBase card, Transform lastCardPos)
    {
        yield return new WaitForEndOfFrame();

        // Add the card to the stacked cards list
        stackedCards.Add(card);

        card.transform.DOMove(lastCardPos.position, .25f);

        yield return new WaitForSeconds(0.25f);
        // Update the card's position in the stack
        UpdateCardPosition(card);

        if (!card.IsFaceUp)
        {
            yield break;
        }

        yield return new WaitForSeconds(0.1f);
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
        SpriteRenderer selectedSpriteSpriteRenderer = card.selectedSprite.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.sortingOrder = sortingOrder;
            selectedSpriteSpriteRenderer.sortingOrder = sortingOrder;
        }
    }

    public void GetlastCard()
    {
        int last = stackedCards.Count - 1;
        if (!stackedCards[last].IsFaceUp)
        {
            return;
        }
        stackedCards[last].SelectCard();
    }

    public Transform GetLastCardPosition()
    {
        int last = stackedCards.Count - 1;
        Debug.Log(stackedCards[last].gameObject.name);
        return stackedCards[last].transform;
    }

    public void DestroyConsecutiveDuplicateCards()
    {
        int count = stackedCards.Count;
        if (count >= 3)
        {

            for (int i = count - 1; i >= 2; i--)
            {
                if (!stackedCards[i - 1].GetComponent<CardBase>().IsFaceUp)
                {
                    return;
                }

                if (!stackedCards[i - 2].GetComponent<CardBase>().IsFaceUp)
                {
                    return;
                }
                
                if (stackedCards[i].GetComponent<CardBase>().Value == stackedCards[i - 1].GetComponent<CardBase>().Value &&
                 stackedCards[i].GetComponent<CardBase>().Value == stackedCards[i - 2].GetComponent<CardBase>().Value
                 && stackedCards[i].GetComponent<CardBase>().Type == stackedCards[i - 1].GetComponent<CardBase>().Type &&
                  stackedCards[i].GetComponent<CardBase>().Type == stackedCards[i - 2].GetComponent<CardBase>().Type)
                {
                    Destroy(stackedCards[i].gameObject);
                    Destroy(stackedCards[i - 1].gameObject);
                    Destroy(stackedCards[i - 2].gameObject);
                    stackedCards.RemoveAt(i);
                    Instantiate(CardEffect, stackedCards[i - 2].gameObject.transform.position, Quaternion.identity);
                    stackedCards.RemoveAt(i - 1);
                    stackedCards.RemoveAt(i - 2);
                    FindObjectOfType<AudioManagerCS>().Play("Cards Destroy");

                    ScoreManager.instance.AddScore(10);
                    FindObjectOfType<GameoverViewManager>().AddScore(10);

                    foreach (CardBase stackedCard in stackedCards)
                    {
                        UpdateCardPosition(stackedCard);
                    }
                    break;

                }
                else if (stackedCards[i].GetComponent<CardBase>().Value == stackedCards[i - 1].GetComponent<CardBase>().Value &&
                    stackedCards[i].GetComponent<CardBase>().Value == stackedCards[i - 2].GetComponent<CardBase>().Value)
                {
                    Destroy(stackedCards[i].gameObject);
                    Destroy(stackedCards[i - 1].gameObject);
                    Destroy(stackedCards[i - 2].gameObject);
                    stackedCards.RemoveAt(i);
                    Instantiate(CardEffect, stackedCards[i - 2].gameObject.transform.position, Quaternion.identity);
                    stackedCards.RemoveAt(i - 1);
                    stackedCards.RemoveAt(i - 2);
                    FindObjectOfType<AudioManagerCS>().Play("Cards Destroy");

                    ScoreManager.instance.AddScore(5);
                    FindObjectOfType<GameoverViewManager>().AddScore(5);
                    foreach (CardBase stackedCard in stackedCards)
                    {
                        UpdateCardPosition(stackedCard);
                    }
                    break;

                  
                }
            }
        }


    }


    public void DestroyConsecutiveSequentialCards()
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
                    FindObjectOfType<AudioManagerCS>().Play("Cards Destroy");
                    Instantiate(CardEffect, transform.position, Quaternion.identity);
                    ScoreManager.instance.AddScore(10);
                    FindObjectOfType<GameoverViewManager>().AddScore(10);
                    foreach (CardBase stackedCard in stackedCards)
                    {
                        UpdateCardPosition(stackedCard);
                    }
                    break;

                   
                }
            }
        }
    }

    
}
