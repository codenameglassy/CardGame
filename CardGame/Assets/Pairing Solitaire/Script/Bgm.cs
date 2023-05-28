using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       
        bgm();
    }

    // Update is called once per frame
    void bgm()
    {
        FindObjectOfType<AudioManagerCS>().Play("BackGround");
    }
}
