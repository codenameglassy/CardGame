using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageManager : MonoBehaviour
{
    public GameObject ThisPage;
    public GameObject NextPage;

    public void PageTwo()
    {
        ThisPage.SetActive(false);
        NextPage.SetActive(true);
    }

    // Update is called once per frame
  
}
