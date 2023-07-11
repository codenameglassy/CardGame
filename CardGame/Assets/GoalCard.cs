using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalCard : MonoBehaviour
{
    public CardType myCardType;
    public CardSubType myCardSubType;
    public int myCardGoalNumber;
    public TextMeshProUGUI myCardGoalText;

    public enum CardType
    {
        None,
        K,
        Q,
        J
    }

    public enum CardSubType
    {
        None,
        Heart,
        Club,
        Diamond,
        Spade
    }

    public void UpdateCardGoalNumber(int number)
    {
        myCardGoalNumber = number;
        myCardGoalText.text = myCardGoalNumber.ToString();
    }

    public void DeductCardGoalNumber()
    {
      
        myCardGoalNumber--;
      
        if (myCardGoalNumber <= 0)
        {
            myCardGoalNumber = 0;
            myCardGoalText.text = "Done";
            return;
        }

        myCardGoalText.text = myCardGoalNumber.ToString();

    }
}
