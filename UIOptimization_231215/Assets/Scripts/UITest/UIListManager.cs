using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIListManager : MonoBehaviour
{
    public UITestData testData;

    public RectTransform container;
    public GameObject UIPrefab;
    public float spacing = 10f;

    public Sprite[] sprites;

    private RectTransform uiPrefabRectTrn;
    private float startContainerHeight;

    private void Awake()
    {
        uiPrefabRectTrn = UIPrefab.GetComponent<RectTransform>();
        startContainerHeight = uiPrefabRectTrn.sizeDelta.y;
        SetContainer();
    }

    private void Start()
    {
        for (int i = 0; i < testData.startNum; i++)
        {
            AddUI();
        }
    }

    public void AddUI()
    {
        testData.nowNum++;
        SetContainer();
        GameObject newUI = Instantiate(UIPrefab, container);

        SetListElement setElement = newUI.GetComponent<SetListElement>();
        setElement.SetID(testData.nowNum-1);
        setElement.SetName(testData.nowName);
        setElement.SetImage(sprites[(int)Random.Range(0, sprites.Length)]);

        if (!newUI.activeSelf) newUI.SetActive(true);
    }

    private void SetContainer()
    {
        float containerHeight = (uiPrefabRectTrn.sizeDelta.y * testData.nowNum) + (spacing * (testData.nowNum - 1));

        if (containerHeight > startContainerHeight) container.sizeDelta = new Vector2(container.sizeDelta.x, containerHeight);
    }
}
