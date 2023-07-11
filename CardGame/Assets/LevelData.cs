using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelData : MonoBehaviour
{
    public static LevelData instance;
    public GoalData myGoalData;

    public List<GoalData> goalDataList = new List<GoalData>();

    [Header("Canvas")]
    public TextMeshProUGUI levelText;
    private void Awake()
    {
        instance = this;


        LoadCurrentLevel();
       
    }



    private void Start()
    {
        RandomizeGoalData();
    }

    void RandomizeGoalData()
    {
         

        //Random Card Type
        for (int i = 0; i < goalDataList[LevelSetting.currentLevel].numberOfGoalCard; i++)
        {
            int index = Random.Range(1, 4); // 1 is K, 2 is Q, 3 si J
            switch (index)
            {
                case 1:
                    goalDataList[LevelSetting.currentLevel].targetCards[i] = GoalData.CardType.K;
                    break;
                case 2:
                    goalDataList[LevelSetting.currentLevel].targetCards[i] = GoalData.CardType.Q;
                    break;
                case 3:
                    goalDataList[LevelSetting.currentLevel].targetCards[i] = GoalData.CardType.J;
                    break;
            }
        }

        //Random Card Sub Type
        for (int i = 0; i < goalDataList[LevelSetting.currentLevel].numberOfGoalCard; i++)
        {
            int index = Random.Range(1, 5); // 1 is heart, 2 is diamond, 3 is spade, 4 is club
            switch (index) 
            {
                case 1:
                    goalDataList[LevelSetting.currentLevel].targetSubCards[i] = GoalData.CardSubType.Heart;
                    break;
                case 2:
                    goalDataList[LevelSetting.currentLevel].targetSubCards[i] = GoalData.CardSubType.Diamond;
                    break;
                case 3:
                    goalDataList[LevelSetting.currentLevel].targetSubCards[i] = GoalData.CardSubType.Spade;
                    break;
                case 4:
                    goalDataList[LevelSetting.currentLevel].targetSubCards[i] = GoalData.CardSubType.Club;
                    break;
            }
          
        }

        for (int i = 0; i < goalDataList.Count; i++)
        {
            goalDataList[i].spawnableItems.Clear();
        }

        PopulateSpawnable();
    }

  

    void PopulateSpawnable()
    {
        for (int i = 0; i < goalDataList[LevelSetting.currentLevel].targetGoalForCard[0]; i++)
        {
            switch (goalDataList[LevelSetting.currentLevel].targetCards[0])
            {
                case GoalData.CardType.K:

                    switch (goalDataList[LevelSetting.currentLevel].targetSubCards[0])
                    {
                        case GoalData.CardSubType.Heart:
                           goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].heartCards[0]);
                         
                            break;
                        case GoalData.CardSubType.Club:
                          
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].clubCards[0]);
                            
                            break;
                        case GoalData.CardSubType.Diamond:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].diamondCards[0]);
                            
                            break;
                        case GoalData.CardSubType.Spade:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].spadeCards[0]);
                           
                            break;

                        case GoalData.CardSubType.None:

                            break;
                    }
                    break;

                case GoalData.CardType.Q:
                    switch (goalDataList[LevelSetting.currentLevel].targetSubCards[0])
                    {
                        case GoalData.CardSubType.Heart:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].heartCards[1]);
                            
                            break;
                        case GoalData.CardSubType.Club:
                            goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].clubCards[1]);
                            
                            break;
                        case GoalData.CardSubType.Diamond:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].diamondCards[1]);
                            
                            break;
                        case GoalData.CardSubType.Spade:
                           
                               goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].spadeCards[1]);
                            
                            break;

                        case GoalData.CardSubType.None:

                            break;
                    }
                    break;

                case GoalData.CardType.J:
                    switch (goalDataList[LevelSetting.currentLevel].targetSubCards[0])
                    {
                        case GoalData.CardSubType.Heart:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].heartCards[2]);
                            
                            break;
                        case GoalData.CardSubType.Club:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].clubCards[2]);
                            
                            break;
                        case GoalData.CardSubType.Diamond:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].diamondCards[2]);
                            
                            break;
                        case GoalData.CardSubType.Spade:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].spadeCards[2]);
                            
                            break;

                        case GoalData.CardSubType.None:

                            break;
                    }
                    break;

                case GoalData.CardType.None:
                    break;
            }
        }

        for (int i = 0; i < goalDataList[LevelSetting.currentLevel].targetGoalForCard[1]; i++)
        {
            switch (goalDataList[LevelSetting.currentLevel].targetCards[1])
            {
                case GoalData.CardType.K:

                    switch (goalDataList[LevelSetting.currentLevel].targetSubCards[1])
                    {
                        case GoalData.CardSubType.Heart:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].heartCards[0]);
                            
                            break;
                        case GoalData.CardSubType.Club:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].clubCards[0]);
                            
                            break;
                        case GoalData.CardSubType.Diamond:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].diamondCards[0]);
                            
                            break;
                        case GoalData.CardSubType.Spade:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].spadeCards[0]);
                           
                            break;

                        case GoalData.CardSubType.None:

                            break;
                    }
                    break;

                case GoalData.CardType.Q:
                    switch (goalDataList[LevelSetting.currentLevel].targetSubCards[1])
                    {
                        case GoalData.CardSubType.Heart:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].heartCards[1]);
                            
                            break;
                        case GoalData.CardSubType.Club:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].clubCards[1]);
                            
                            break;
                        case GoalData.CardSubType.Diamond:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].diamondCards[1]);
                            
                            break;
                        case GoalData.CardSubType.Spade:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].spadeCards[1]);
                            
                            break;

                        case GoalData.CardSubType.None:

                            break;
                    }
                    break;

                case GoalData.CardType.J:
                    switch (goalDataList[LevelSetting.currentLevel].targetSubCards[1])
                    {
                        case GoalData.CardSubType.Heart:

                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].heartCards[2]);
                            
                            break;
                        case GoalData.CardSubType.Club:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].clubCards[2]);
                            
                            break;
                        case GoalData.CardSubType.Diamond:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].diamondCards[2]);
                            
                            break;
                        case GoalData.CardSubType.Spade:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].spadeCards[2]);
                            
                            break;

                        case GoalData.CardSubType.None:

                            break;
                    }
                    break;

                case GoalData.CardType.None:
                    break;
            }
        }

        for (int i = 0; i < goalDataList[LevelSetting.currentLevel].targetGoalForCard[2]; i++)
        {
            switch (goalDataList[LevelSetting.currentLevel].targetCards[2])
            {
                case GoalData.CardType.K:

                    switch (goalDataList[LevelSetting.currentLevel].targetSubCards[2])
                    {
                        case GoalData.CardSubType.Heart:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].heartCards[0]);
                            
                            break;
                        case GoalData.CardSubType.Club:
                          
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].clubCards[0]);
                            
                            break;
                        case GoalData.CardSubType.Diamond:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].diamondCards[0]);
                            
                            break;
                        case GoalData.CardSubType.Spade:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].spadeCards[0]);
                            
                            break;

                        case GoalData.CardSubType.None:

                            break;
                    }
                    break;

                case GoalData.CardType.Q:
                    switch (goalDataList[LevelSetting.currentLevel].targetSubCards[2])
                    {
                        case GoalData.CardSubType.Heart:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].heartCards[1]);
                            
                            break;
                        case GoalData.CardSubType.Club:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].clubCards[1]);
                            
                            break;
                        case GoalData.CardSubType.Diamond:
                         
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].diamondCards[1]);
                            
                            break;
                        case GoalData.CardSubType.Spade:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].spadeCards[1]);
                            
                            break;

                        case GoalData.CardSubType.None:

                            break;
                    }
                    break;

                case GoalData.CardType.J:
                    switch (goalDataList[LevelSetting.currentLevel].targetSubCards[2])
                    {
                        case GoalData.CardSubType.Heart:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].heartCards[2]);
                            
                            break;
                        case GoalData.CardSubType.Club:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].clubCards[2]);
                            
                            break;
                        case GoalData.CardSubType.Diamond:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].diamondCards[2]);
                            
                            break;
                        case GoalData.CardSubType.Spade:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].spadeCards[2]);
                            
                            break;

                        case GoalData.CardSubType.None:

                            break;
                    }
                    break;

                case GoalData.CardType.None:
                    break;
            }
        }

        for (int i = 0; i < goalDataList[LevelSetting.currentLevel].targetGoalForCard[3]; i++)
        {
            switch (goalDataList[LevelSetting.currentLevel].targetCards[3])
            {
                case GoalData.CardType.K:

                    switch (goalDataList[LevelSetting.currentLevel].targetSubCards[3])
                    {
                        case GoalData.CardSubType.Heart:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].heartCards[0]);
                          
                            break;
                        case GoalData.CardSubType.Club:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].clubCards[0]);
                          
                            break;
                        case GoalData.CardSubType.Diamond:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].diamondCards[0]);
                         
                            break;
                        case GoalData.CardSubType.Spade:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].spadeCards[0]);
                           
                            break;

                        case GoalData.CardSubType.None:

                            break;
                    }
                    break;

                case GoalData.CardType.Q:
                    switch (goalDataList[LevelSetting.currentLevel].targetSubCards[3])
                    {
                        case GoalData.CardSubType.Heart:

                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].heartCards[1]);
                         
                            break;
                        case GoalData.CardSubType.Club:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].clubCards[1]);
                          
                            break;
                        case GoalData.CardSubType.Diamond:
                           
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].diamondCards[1]);
                         
                            break;
                        case GoalData.CardSubType.Spade:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].spadeCards[1]);
                          
                            break;

                        case GoalData.CardSubType.None:

                            break;
                    }
                    break;

                case GoalData.CardType.J:
                    switch (goalDataList[LevelSetting.currentLevel].targetSubCards[3])
                    {
                        case GoalData.CardSubType.Heart:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].heartCards[2]);
                          
                            break;
                        case GoalData.CardSubType.Club:
                            
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].clubCards[2]);
                           
                            break;
                        case GoalData.CardSubType.Diamond:
                          
                                goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].diamondCards[2]);
                          
                            break;
                        case GoalData.CardSubType.Spade:
                           
                             goalDataList[LevelSetting.currentLevel].spawnableItems.Add(goalDataList[LevelSetting.currentLevel].spadeCards[2]);
                           
                            break;

                        case GoalData.CardSubType.None:

                            break;
                    }
                    break;

                case GoalData.CardType.None:
                    break;
            }
        }
    }


    IEnumerator Enum_LoadLevelData()
    {
        LoadCurrentLevel();
        yield return new WaitForEndOfFrame();
        RandomizeGoalData();
        
       

    }

    public void LoadCurrentLevel()
    {
        myGoalData = goalDataList[LevelSetting.currentLevel];
        levelText.text = "Level: " + (LevelSetting.currentLevel + 1).ToString();
    }

}
