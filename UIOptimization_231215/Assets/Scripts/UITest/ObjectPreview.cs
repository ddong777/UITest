using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPreview : MonoBehaviour
{
    public Transform targetTransform; // 선택한 오브젝트의 Transform

    private void Start()
    {
        // 선택한 오브젝트의 크기 값을 현재 오브젝트에 적용
        transform.localScale = targetTransform.localScale;
    }

    void Update()
    {
        if (targetTransform != null)
        {
            // 선택한 오브젝트의 회전 값을 현재 오브젝트에 적용
            transform.rotation = targetTransform.rotation;            
        }
    }
}
