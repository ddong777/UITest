using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardItem : MonoBehaviour
{
    public Text cardText;
    private float height;

    void Awake()
    {
        cardText = GetComponentInChildren<Text>();
    }

    public void SetHeight(float newHeight)
    {
        height = newHeight;
    }

    public void SetPosition(float yPos)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0f, yPos);
    }

    public void UpdateCardData(int dataIndex)
    {
        cardText.text = dataIndex.ToString();
    }
}
