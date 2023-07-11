using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShineMask : MonoBehaviour
{
    public Animator anim;

    public void Shine()
    {
        anim.SetTrigger("shine");
    }

}
