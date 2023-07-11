using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public CardBase selectedCard;
    public Slot selectedCardSlot;

    public List<Slot> slotList = new List<Slot>();
    int slotIndex = 1;

    [HideInInspector]public Slot currentSlotToSpawn;
    
    public bool hasGameStarted = false;

    public CanvasGroup fadeCanvas;
    private void Awake()
    {
        instance = this;
        fadeCanvas.alpha = 1.0f;
    }
    // Start is called before the first frame update
    void Start()
    {
        fadeCanvas.DOFade(0, 2f);
       // DelayStartGame();
        if (selectedCardSlot != null)
            selectedCardSlot.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void Update()
    {
       
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D[] hit = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            foreach (RaycastHit2D hit_ in hit)
            {
                if (hit_.collider.CompareTag("Slot"))
                {

                    if(selectedCardSlot == hit_.collider.GetComponent<Slot>())
                    {
                        Debug.Log("Same slot");
                        return;
                    }
                   
                    if(selectedCard == null)
                    {
                        Slot hitSlot = hit_.collider.GetComponent<Slot>();

                        if(hitSlot.stackedCards.Count <= 0)
                        {
                            return;
                        }
                        hitSlot.GetlastCard();
                        Debug.Log(hitSlot.gameObject.name);
                        //selectedCard.spriteRenderer.color = Color.yellow;
                        selectedCard.selectedSprite.SetActive(true);
                        selectedCardSlot = hitSlot;
                        
                    }
                    else if(selectedCard != null)
                    {
                        Slot targetSlot = hit_.collider.GetComponent<Slot>();
                        selectedCard.MoveCard(selectedCardSlot, targetSlot);
                        FindObjectOfType<AudioManagerCS>().Play("Card Transfer");
                        //selectedCard.spriteRenderer.color = Color.white;
                        selectedCard.selectedSprite.SetActive(false);

                        //clear
                        selectedCard = null;
                        selectedCardSlot = null;
                    }
                  
                }
            }

        }
    }

    public void SelectRandomSlot()
    {
        switch (slotIndex)
        {
            case 1:
                currentSlotToSpawn = slotList[0];
                slotIndex = 2;
                break;
            case 2:
                currentSlotToSpawn = slotList[1];
                slotIndex = 3;

                break;
            case 3:
                currentSlotToSpawn = slotList[2];
                slotIndex = 4;

                break;
            case 4:
                currentSlotToSpawn = slotList[3];
                slotIndex = 5;
                break;

            case 5:
                currentSlotToSpawn = slotList[4];
                slotIndex = 1;
                break;
            /*
            case 6:
                currentSlotToSpawn = slotList[5];
                slotIndex = 7;
                break;

            case 7:
                currentSlotToSpawn = slotList[6];
                slotIndex = 1;
                break;
            */
                
           
        }
    }

   public void GameStarter()
    {
        hasGameStarted = true;
        if (Settings.myGameMode == Settings.gamemode.versionTwo)
        {
            FaceUpAllCards();
        }
    }
    
   public void DelayStartGame()
    {
        Invoke("GameStarter", 6f);
      
    }


    public void FaceUpAllCards()
    {
        CardBase[] cards = FindObjectsOfType<CardBase>();
        // Create a list to store the objects
        List<CardBase> cardList = new List<CardBase>();
        cardList.AddRange(cards);

        Slot[] slots = FindObjectsOfType<Slot>();
        List<Slot> slotList = new List<Slot>();
        slotList.AddRange(slots);


        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].FlipFaceUp();

            /*for (int j = 0; j < slots.Length; j++)
            {
                slots[i].DestroyConsecutiveDuplicateCards();
                slots[i].DestroyConsecutiveSequentialCards();
            }*/
        }
    }

   

}
