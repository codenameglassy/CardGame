using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MovesTracker : MonoBehaviour
{
    public int totalMoves = 26; // Total number of moves allowed
    public TextMeshProUGUI movesText; // Reference to the UI Text component displaying moves left

    private int movesLeft; // Current number of moves left
    public GameObject GameOverView;
    private void Start()
    {
        movesLeft = totalMoves;
        UpdateMovesText();
       
    }

    public void DeductMove()
    {
        movesLeft--;
        UpdateMovesText();

        
    }

    private void UpdateMovesText()
    {
        movesText.text = movesLeft.ToString();
        if (movesLeft <= 0)
        {

            GameOverView.SetActive(true);
            // Perform necessary actions when moves run out
            Debug.Log("No more moves left!");

        }
    }
}