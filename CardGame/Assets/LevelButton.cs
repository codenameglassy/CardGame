using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    [Header("Properties")]
    public ButtonState myButtonState;
    public enum ButtonState
    {
        Unselected,
        Selected,
        Locked
    }
    public Sprite unselectedSprite;
    public Sprite selectedSprite;
    public Sprite lockedSprite;
    public Image myButtonImage;

    [Header("Description")]
    public bool isHardlevel = false;
    public int myLevelNumber;

    [Header("Decor")]
    public List<GameObject> unselectedDecor = new List<GameObject>();
    public List<GameObject> selectedDecor = new List<GameObject>();
    public List<GameObject> lockedDecor = new List<GameObject>();
    public List<GameObject> hardLevelDecor = new List<GameObject>();

    private Button myButton;
    private void Awake()
    {
        myButton = GetComponent<Button>();
    }
    private void Start()
    {
        myButton.onClick.AddListener(SelectThis);
        SwitchButtonState();
    }
    public void SwitchButtonState()
    {
        CheckLevelDiscription();
        switch (myButtonState)
        {
            case ButtonState.Unselected:
                myButtonImage.sprite = unselectedSprite;

                for (int i = 0; i < unselectedDecor.Count; i++)
                {
                    unselectedDecor[i].SetActive(true);
                }
                break;

            case ButtonState.Selected:
                myButtonImage.sprite = selectedSprite;

                LevelSetting.currentLevel = myLevelNumber - 1;
                LevelHandler.instance.selectedBtn = this;
                LevelHandler.instance.selectedLevelNumber.text = "Level " + myLevelNumber.ToString();

                for (int i = 0; i < selectedDecor.Count; i++)
                {
                    selectedDecor[i].SetActive(true);
                }
                break;

            case ButtonState.Locked:
                myButtonImage.sprite = lockedSprite;

                for (int i = 0; i < lockedDecor.Count; i++)
                {
                    lockedDecor[i].SetActive(true);
                }
                break;
        }
    }

    void CheckLevelDiscription()
    {
        if (isHardlevel)
        {

            for (int i = 0; i < hardLevelDecor.Count; i++)
            {
                hardLevelDecor[i].SetActive(true);
            }
        }
    }

    public void SelectThis()
    {
        StartCoroutine(EnumSelectThis());
    }

    IEnumerator EnumSelectThis()
    {
        yield return new WaitForEndOfFrame();

        if(myButtonState == ButtonState.Locked)
        {
            yield break;
        }

        LevelHandler.instance.selectedBtn.UnSelectThis();

        yield return new WaitForEndOfFrame();

        LevelHandler.instance.selectedBtn = this;
        LevelSetting.currentLevel = myLevelNumber - 1;

        myButtonState = ButtonState.Selected;
        SwitchButtonState();
    }

    

    public void UnSelectThis()
    {
        myButtonState = ButtonState.Unselected;
        SwitchButtonState();
    }
}
