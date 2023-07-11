using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class MovesTracker : MonoBehaviour
{
    public static MovesTracker instance;
    public int totalMoves = 26; // Total number of moves allowed
    public TextMeshProUGUI movesText; // Reference to the UI Text component displaying moves left

    [HideInInspector]public int movesLeft; // Current number of moves left
    public GameObject GameOverView;


    [Header("Goal Tracking")]
    //public GoalData goalData;
    public List<Image> goalPanelHeaderList = new List<Image>();
    public List<Image> goalImageList = new List<Image>();
    //public List<Sprite> cardSprites = new List<Sprite>();
    public Sprite[] cardSpritesHeart;
    public Sprite[] cardSpritesDiamond;
    public Sprite[] cardSpritesSpade;
    public Sprite[] cardSpritesClub;
    //public List<TextMeshProUGUI> cardGoalText = new List<TextMeshProUGUI>();
    public List<GoalCard> goalCardsScriptList = new List<GoalCard>();

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {

        InvokeRepeating("CheckRemainingCards", 3f, 1f);
        Invoke("SetLevel", 1f);
    }

    public void DeductMove()
    {
        movesLeft--;
        movesText.text = movesLeft.ToString();
        if (movesLeft <= 0)
        {
            Debug.Log("No more moves left!");
            GameOverView.SetActive(true);

        }
    }

    public void CheckRemainingCards()
    {
        CardBase[] cards = FindObjectsOfType<CardBase>();

        if(cards.Length <= 0)
        {
            GameOverView.SetActive(true);
            return;
        }
    }


    public void SetLevel()
    {
        //enable the cards in goal Panel
        for (int i = 0; i < LevelData.instance.myGoalData.numberOfGoalCard; i++)
        {
            goalPanelHeaderList[i].gameObject.SetActive(true);
           // cardGoalText[i].text = goalData.targetGoalForCard[i].ToString();
            goalCardsScriptList[i].UpdateCardGoalNumber(LevelData.instance.myGoalData.targetGoalForCard[i]);
        }

        //set base move 
        totalMoves = (LevelData.instance.myGoalData.numberOfCardsToSpawn / 3) * 2 + 15;
        movesLeft = totalMoves;
        movesText.text = movesLeft.ToString();

        //Set Sprite In Goal Panel
        SetSpriteFromGoalData();
       

     
    }


    public void SetSpriteFromGoalData()
    {
        for (int i = 0; i < LevelData.instance.myGoalData.numberOfGoalCard; i++)
        {

            if(LevelData.instance.myGoalData.targetCards[i] == GoalData.CardType.K)
            {
                if(LevelData.instance.myGoalData.targetSubCards[i] == GoalData.CardSubType.Heart)
                {
                    goalImageList[i].sprite = cardSpritesHeart[0];
                    goalCardsScriptList[i].myCardType = GoalCard.CardType.K;
                    goalCardsScriptList[i].myCardSubType = GoalCard.CardSubType.Heart;
                }
                if (LevelData.instance.myGoalData.targetSubCards[i] == GoalData.CardSubType.Diamond)
                {
                    goalImageList[i].sprite = cardSpritesDiamond[0];
                    goalCardsScriptList[i].myCardType = GoalCard.CardType.K;
                    goalCardsScriptList[i].myCardSubType = GoalCard.CardSubType.Diamond;
                }
                if (LevelData.instance.myGoalData.targetSubCards[i] == GoalData.CardSubType.Spade)
                {
                    goalImageList[i].sprite = cardSpritesSpade[0];
                    goalCardsScriptList[i].myCardType = GoalCard.CardType.K;
                    goalCardsScriptList[i].myCardSubType = GoalCard.CardSubType.Spade;
                }
                if (LevelData.instance.myGoalData.targetSubCards[i] == GoalData.CardSubType.Club)
                {
                    goalImageList[i].sprite = cardSpritesClub[0];
                    goalCardsScriptList[i].myCardType = GoalCard.CardType.K;
                    goalCardsScriptList[i].myCardSubType = GoalCard.CardSubType.Club;
                }
            }

            if (LevelData.instance.myGoalData.targetCards[i] == GoalData.CardType.Q)
            {
                if (LevelData.instance.myGoalData.targetSubCards[i] == GoalData.CardSubType.Heart)
                {
                    goalImageList[i].sprite = cardSpritesHeart[1];
                    goalCardsScriptList[i].myCardType = GoalCard.CardType.Q;
                    goalCardsScriptList[i].myCardSubType = GoalCard.CardSubType.Heart;
                }
                if (LevelData.instance.myGoalData.targetSubCards[i] == GoalData.CardSubType.Diamond)
                {
                    goalImageList[i].sprite = cardSpritesDiamond[1];
                    goalCardsScriptList[i].myCardType = GoalCard.CardType.Q;
                    goalCardsScriptList[i].myCardSubType = GoalCard.CardSubType.Diamond;
                }
                if (LevelData.instance.myGoalData.targetSubCards[i] == GoalData.CardSubType.Spade)
                {
                    goalImageList[i].sprite = cardSpritesSpade[1];
                    goalCardsScriptList[i].myCardType = GoalCard.CardType.Q;
                    goalCardsScriptList[i].myCardSubType = GoalCard.CardSubType.Spade;
                }
                if (LevelData.instance.myGoalData.targetSubCards[i] == GoalData.CardSubType.Club)
                {
                    goalImageList[i].sprite = cardSpritesClub[1];
                    goalCardsScriptList[i].myCardType = GoalCard.CardType.Q;
                    goalCardsScriptList[i].myCardSubType = GoalCard.CardSubType.Club;
                }
            }

            if (LevelData.instance.myGoalData.targetCards[i] == GoalData.CardType.J)
            {
                if (LevelData.instance.myGoalData.targetSubCards[i] == GoalData.CardSubType.Heart)
                {
                    goalImageList[i].sprite = cardSpritesHeart[2];
                    goalCardsScriptList[i].myCardType = GoalCard.CardType.J;
                    goalCardsScriptList[i].myCardSubType = GoalCard.CardSubType.Heart;
                }
                if (LevelData.instance.myGoalData.targetSubCards[i] == GoalData.CardSubType.Diamond)
                {
                    goalImageList[i].sprite = cardSpritesDiamond[2];
                    goalCardsScriptList[i].myCardType = GoalCard.CardType.J;
                    goalCardsScriptList[i].myCardSubType = GoalCard.CardSubType.Diamond;
                }
                if (LevelData.instance.myGoalData.targetSubCards[i] == GoalData.CardSubType.Spade)
                {
                    goalImageList[i].sprite = cardSpritesSpade[2];
                    goalCardsScriptList[i].myCardType = GoalCard.CardType.J;
                    goalCardsScriptList[i].myCardSubType = GoalCard.CardSubType.Spade;
                }
                if (LevelData.instance.myGoalData.targetSubCards[i] == GoalData.CardSubType.Club)
                {
                    goalImageList[i].sprite = cardSpritesClub[2];
                    goalCardsScriptList[i].myCardType = GoalCard.CardType.J;
                    goalCardsScriptList[i].myCardSubType = GoalCard.CardSubType.Club;
                }
            }


        }
    }
}
