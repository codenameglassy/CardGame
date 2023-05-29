using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public CardBase selectedCard;
    public Slot selectedCardSlot;

    public List<Slot> slotList = new List<Slot>();
    int slotIndex = 1;

    [HideInInspector]public Slot currentSlotToSpawn;
    
    public bool hasGameStarted = false;
    private void Awake()
    {
        instance = this;
      
    }
    // Start is called before the first frame update
    void Start()
    {
        DelayStartGame();
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
                    if(selectedCard == null)
                    {
                        Slot hitSlot = hit_.collider.GetComponent<Slot>();

                        if(hitSlot.stackedCards.Count <= 0)
                        {
                            return;
                        }
                        hitSlot.GetlastCard();
                        Debug.Log(hitSlot.gameObject.name);
                        selectedCard.GetComponent<SpriteRenderer>().color = Color.yellow;
                        selectedCardSlot = hitSlot;
                        
                    }
                    else if(selectedCard != null)
                    {
                        Slot targetSlot = hit_.collider.GetComponent<Slot>();
                        selectedCard.MoveCard(selectedCardSlot, targetSlot);
                        FindObjectOfType<AudioManagerCS>().Play("Card Transfer");
                        selectedCard.GetComponent<SpriteRenderer>().color = Color.white;
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
                currentSlotToSpawn = slotList[4];
                slotIndex = 5;
                break;
            case 5:
                currentSlotToSpawn = slotList[3];
                slotIndex = 1;
                break;
                
           
        }
    }

   public void GameStarter()
    {
       hasGameStarted = true;
    }
    
   public void DelayStartGame()
    {
        Invoke("GameStarter", 6f);
    }

   

}