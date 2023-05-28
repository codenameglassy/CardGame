using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    
  
    public void LoadScene(string name)
    {
        FindObjectOfType<AudioManagerCS>().Play("Card Touch");
        SceneManager.LoadScene(name);
    }
   

    

}
