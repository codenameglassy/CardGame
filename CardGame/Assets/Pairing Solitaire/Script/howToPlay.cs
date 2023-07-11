using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class howToPlay : MonoBehaviour
{
    [SerializeField]private GameObject htpImage;

    private void Start()
    {
      //  htpImage.SetActive(false);
    }

    bool toggle;
    public void HTP()
    {
        toggle = !toggle;
        FindObjectOfType<AudioManagerCS>().Play("Card Touch");
        if (toggle)
        {
            htpImage.SetActive(true);
        }
        else if (!toggle)
        {
            htpImage.SetActive(false);
        }
    }

    public void HtpPageState(bool state)
    {
        htpImage.SetActive(state);
    }
}
