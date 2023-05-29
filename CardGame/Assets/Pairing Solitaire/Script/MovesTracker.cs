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
        movesText.text = movesLeft.ToString();

    }

    public void DeductMove()
    {
        movesLeft--;
        movesText.text = movesLeft.ToString();
        if (movesLeft <= 0)
        {
            Debug.Log("No more moves left!");
            GameOverView.SetActive(true);

        }
    }

}