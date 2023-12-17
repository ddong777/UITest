using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public Animator pauseImgAnim;
    public Animator listImgAnim;
    private bool isPause = false;

    public void PlayAnim()
    {
        isPause = !isPause;
        pauseImgAnim.SetBool("IsButtonPress", isPause);
        listImgAnim.SetBool("IsPause", isPause);
    }
}
