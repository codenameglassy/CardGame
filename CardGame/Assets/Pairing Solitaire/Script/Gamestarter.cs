using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gamestarter : MonoBehaviour
{
    
    // Start is called before the first frame update
   
   public void Gamestart()
    {
        GameManager.instance.GameStarter();
    }
    public void VersionOne()
    {
        GameManager.instance.DelayStartGame();
    }
}
