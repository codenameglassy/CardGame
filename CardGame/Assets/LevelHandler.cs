using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelHandler : MonoBehaviour
{
    public static LevelHandler instance;
    public LevelButton selectedBtn;
    public List<LevelButton> LevelBtns = new List<LevelButton>();


    public TextMeshProUGUI selectedLevelNumber;

    private void Awake()
    {
        instance = this;
      
    }

    // Start is called before the first frame update
    void Start()
    {
        LevelSetting.lastMaxLevel = PlayerPrefs.GetInt("lastMaxLevel");
        UdpateButtonStatesByLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UnselectTheCurrent()
    {

    }

    void UdpateButtonStatesByLevel()
    {
        for (int i = 0; i < LevelSetting.lastMaxLevel + 1; i++)
        {

            if (i == LevelSetting.lastMaxLevel)
            {
                LevelBtns[i].myButtonState = LevelButton.ButtonState.Selected;
                LevelBtns[i].SwitchButtonState();
                break;
             
            }

            LevelBtns[i].myButtonState = LevelButton.ButtonState.Unselected;
            LevelBtns[i].SwitchButtonState();

        }
    }


}
