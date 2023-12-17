using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIListManager_Opti : MonoBehaviour
{
    public GameObject cardPrefab;
    public RectTransform contentTransform;
    public ScrollRect scrollRect;

    public int totalItemCount = 500;
    public int visibleItemCount = 13;
    public float itemHeight = 100f;
    public float scrollSpeed = 1f;

    private List<CardItem> cardPool = new List<CardItem>();

    void Start()
    {
        InitializeCards();
    }

    void InitializeCards()
    {
        for (int i = 0; i < visibleItemCount; i++)
        {
            CardItem card = Instantiate(cardPrefab, contentTransform).GetComponent<CardItem>();
            card.transform.SetParent(contentTransform, false);
            card.SetHeight(itemHeight);
            card.gameObject.SetActive(true);
            cardPool.Add(card);
        }

        UpdateCardPositions();
    }

    void UpdateCardPositions()
    {
        float contentHeight = totalItemCount * itemHeight;
        contentTransform.sizeDelta = new Vector2(contentTransform.sizeDelta.x, contentHeight);

        float normalizedPosition = scrollRect.normalizedPosition.y;
        int firstVisibleIndex = Mathf.FloorToInt(normalizedPosition * totalItemCount);

        for (int i = 0; i < visibleItemCount; i++)
        {
            int dataIndex = (firstVisibleIndex + i) % totalItemCount;
            cardPool[i].UpdateCardData(dataIndex);
            cardPool[i].SetPosition(i * itemHeight);
        }
    }

    void Update()
    {
        float scrollDelta = scrollRect.velocity.y * Time.deltaTime;
        scrollRect.normalizedPosition = new Vector2(scrollRect.normalizedPosition.x, Mathf.Clamp01(scrollRect.normalizedPosition.y + scrollDelta / (totalItemCount * itemHeight)));

        UpdateCardPositions();
    }
}
