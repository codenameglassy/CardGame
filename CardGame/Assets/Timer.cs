using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{



    [Header("Health")]
    public int maxHealth;
    private int currentHealth;
    public TextMeshProUGUI healthText;



    [Header("Timer")]
    public TextMeshProUGUI timerText;
    public float maxTimer;
    private float currentTimer;


    private void Start()
    {
        currentHealth = 3;
        healthText.text = currentHealth.ToString();

        currentTimer = maxTimer;
        timerText.text = currentTimer.ToString();

        InvokeRepeating("CheckTimer", 0f, 1f);   
    }

    
    void CheckTimer()
    {
        if(currentHealth >= maxHealth)
        {
            currentTimer = 0;
            int minutes__ = Mathf.FloorToInt(currentTimer / 60);
            int seconds__ = Mathf.FloorToInt(currentTimer % 60);

            string timeText__ = string.Format("{0:00}:{1:00}", minutes__, seconds__);
            timerText.text = timeText__;
            return;
        }

        currentTimer--;

        int minutes = Mathf.FloorToInt(currentTimer / 60);
        int seconds = Mathf.FloorToInt(currentTimer % 60);

        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = timeText;



        if (currentTimer <= 0)
        {
            IncreaseHealth();
            currentTimer = maxTimer;
            int minutes_ = Mathf.FloorToInt(currentTimer / 60);
            int seconds_ = Mathf.FloorToInt(currentTimer % 60);

            string timeText_ = string.Format("{0:00}:{1:00}", minutes_, seconds_);
            timerText.text = timeText_;
        }
    }

    public void IncreaseHealth()
    {
        currentHealth++;
        healthText.text = currentHealth.ToString();
    }

    public void DecreaseHealth()
    {
        currentHealth--;
        healthText.text = currentHealth.ToString();
    }


        
}
