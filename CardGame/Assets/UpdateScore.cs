using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UpdateScore : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI starText;
    private int coinAmount, starAmount;
    // Start is called before the first frame update
    void Start()
    {
        coinAmount = PlayerPrefs.GetInt("coinAmount");
        starAmount = PlayerPrefs.GetInt("starAmount");
        coinText.text = coinAmount.ToString();
        starText.text = starAmount.ToString();
    }

  
}
