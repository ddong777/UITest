using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectListManager : MonoBehaviour
{
    public UITestData testData;
    public GameObject OBJPrefab;
    public Transform container;
    public int startObjNum;

    private void Start()
    {
        for (int i = 0; i < testData.startNum; i++)
        {
            AddObj();
        }
    }

    public void AddObj()
    {
        GameObject newObj = Instantiate(OBJPrefab, container);

        if (!newObj.activeSelf) newObj.SetActive(true);

        RandomRotation randomRotation = newObj.GetComponent<RandomRotation>();
        testData.nowName = randomRotation.randomScaleX.ToString("F1") + " x " + randomRotation.randomScaleY.ToString("F1") + " x " + randomRotation.randomScaleZ.ToString("F1");
    }
}
