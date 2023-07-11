using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level 1", menuName = "Goal Data")]
public class GoalData : ScriptableObject
{

    public int numberOfGoalCard;
    public List<int> targetGoalForCard = new List<int>();


    [Header("My Goal")]
    public List<CardType> targetCards = new List<CardType>();
    public List<CardSubType> targetSubCards = new List<CardSubType>();

    [Header("Cards to Spawn")]
    public List<GameObject> spawnableItems = new List<GameObject>();
    public int numberOfCardsToSpawn;
    public List<GameObject> heartCards = new List<GameObject>();  // K Q J 
    public List<GameObject> diamondCards = new List<GameObject>();  // K Q J 
    public List<GameObject> spadeCards = new List<GameObject>();  // K Q J 
    public List<GameObject> clubCards = new List<GameObject>();  // K Q J 

    public enum CardType
    {
        K,
        Q,
        J,
        None
    }

    public enum CardSubType
    {
        Heart,
        Club,
        Diamond,
        Spade,
        None
    }
}
