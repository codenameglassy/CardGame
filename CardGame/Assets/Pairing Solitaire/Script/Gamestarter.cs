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
        Settings.myGameMode = Settings.gamemode.versionOne;
    }

    public void VersionTwo()
    {
        Settings.myGameMode = Settings.gamemode.versionTwo;

    }
}
