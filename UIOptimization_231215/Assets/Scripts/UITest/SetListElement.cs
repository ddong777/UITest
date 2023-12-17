using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetListElement : MonoBehaviour
{
    public Text nameTxt;
    public Text IDTxt;
    public Image iconImg;
    public int id;

    public void SetID(int num)
    {
        id = num;
        IDTxt.text = id.ToString();
    }

    public void SetName(string name)
    {
        nameTxt.text = name;
    }

    public void SetImage(Sprite sprite)
    {
        iconImg.sprite = sprite;
    }
}
