using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class HomePage : MonoBehaviour
{
    [Header("Shine and Fade")]
    public ShineMask[] shineMasks;
    public CanvasGroup fadeCanvas;
    private int shineMasksCount;
    private int currentIndex = 0;
    private Coroutine processingCoroutine;
    public float interval;


    [Header("Panels")]
    public GameObject optionPanel;
    public Transform[] footerPanelButtons;
    public GameObject[] mainPanels;
    public enum PanelType
    {
        multiplayer,
        store,
        home,
        leaderboard,
        option
    }
    public PanelType currentPanelType;

    private void Awake()
    {
        fadeCanvas.alpha = 1f;
    }
    private void Start()
    {
        shineMasksCount = shineMasks.Length;
        fadeCanvas.DOFade(0, 2f);

        currentPanelType = PanelType.home;
        SwitchPanel();

        Invoke("ShineOnebyOne", 1f);
    }
    private void FixedUpdate()
    {
      
    }

    public void ShineOnebyOne()
    {
        processingCoroutine = StartCoroutine(Process_Shine());
    }

    IEnumerator Process_Shine()
    {
        while (currentIndex < shineMasks.Length)
        {
            // Call your desired function on the current list item
            shineMasks[currentIndex].Shine();

            currentIndex++; // Move to the next item in the list

            yield return new WaitForSeconds(interval); // Wait for the specified interval before processing the next item
        }

        // List processing is complete, stop the coroutine
        StopCoroutine(processingCoroutine);
    }

    public void ShowOrHideOptionPanel(bool state)
    {
        switch (state)
        {
            case true:
                optionPanel.SetActive(true);
                break;

            case false:
                optionPanel.SetActive(false);
                break;
        }
      
    }

    public void SwitchPanel()
    {
        ResetFooterButtons();
        HideAllMainPanel();

        switch (currentPanelType)
        {
            case PanelType.multiplayer:
                //footerPanelButtons[0].transform.DOScale(new Vector2(2, 2), .5f);
                mainPanels[0].SetActive(true);
                break;

            case PanelType.store:
                //footerPanelButtons[1].transform.DOScale(new Vector2(2, 2), .5f);
                mainPanels[1].SetActive(true);
                break;

            case PanelType.home:
               // footerPanelButtons[2].transform.DOScale(new Vector2(2, 2), .5f);
                mainPanels[2].SetActive(true);
                break;

            case PanelType.leaderboard:
                mainPanels[3].SetActive(true);
                break;

            case PanelType.option:
                mainPanels[4].SetActive(true);
                break;
        }
    }

    public void MultiplayerBtn()
    {

        currentPanelType = PanelType.multiplayer;
        SwitchPanel();
    }

    public void StoreBtn()
    {

        currentPanelType = PanelType.store;
        SwitchPanel();
    }

    public void HomeBtn()
    {
        currentPanelType = PanelType.home;
        SwitchPanel();
    }
    public void LeadberboardBtn()
    {
        currentPanelType = PanelType.leaderboard;
        SwitchPanel();
    }

    public void OptionBtn()
    {
        currentPanelType = PanelType.option;
        SwitchPanel();
    }

    void ResetFooterButtons()
    {
        for (int i = 0; i < footerPanelButtons.Length; i++)
        {
            footerPanelButtons[i].transform.DOScale(new Vector2(1, 1), 0.5f);
        }
    }

    void HideAllMainPanel()
    {
        for (int i = 0; i < mainPanels.Length; i++)
        {
            mainPanels[i].SetActive(false);
        }
    }
}
