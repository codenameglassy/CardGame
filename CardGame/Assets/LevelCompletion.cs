using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelCompletion : MonoBehaviour
{
    public TextMeshProUGUI coinText, starText;
    private int coinAmount, starAmount;

    private void OnEnable()
    {
        coinAmount = PlayerPrefs.GetInt("coinAmount");
        starAmount = PlayerPrefs.GetInt("starAmount");

        LevelSetting.currentLevel++;
        Debug.Log(LevelSetting.currentLevel);

        if (LevelSetting.currentLevel >= LevelSetting.lastMaxLevel)
        {
            LevelSetting.lastMaxLevel++;
            Debug.Log(LevelSetting.lastMaxLevel);
            PlayerPrefs.SetInt("lastMaxLevel", LevelSetting.lastMaxLevel);
        }

        Invoke("SubmitScore", 0.5f);
    }

    public void SubmitScore()
    {
        int tempcoinAmount = MovesTracker.instance.movesLeft * 3;
        int tempstarAmount = MovesTracker.instance.movesLeft;

        coinText.text = tempcoinAmount.ToString();
        starText.text = tempstarAmount.ToString();

        coinAmount += tempcoinAmount;
        starAmount += tempstarAmount;

        PlayerPrefs.SetInt("coinAmount", coinAmount);
        PlayerPrefs.SetInt("starAmount", starAmount);
    }
}
