using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPreview : MonoBehaviour
{
    public Transform targetTransform; // ������ ������Ʈ�� Transform

    private void Start()
    {
        // ������ ������Ʈ�� ũ�� ���� ���� ������Ʈ�� ����
        transform.localScale = targetTransform.localScale;
    }

    void Update()
    {
        if (targetTransform != null)
        {
            // ������ ������Ʈ�� ȸ�� ���� ���� ������Ʈ�� ����
            transform.rotation = targetTransform.rotation;            
        }
    }
}
