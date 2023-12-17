using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public float minChangeInterval = 1f;  // �ּ� ���� ����
    public float maxChangeInterval = 3f;  // �ִ� ���� ����
    public float rotationSpeed = 5f;      // ȸ�� �ӵ�
    public float smoothness = 2f;         // ȸ�� �ε巯�� ����
    public float minSize = 0.5f;
    public float maxSize = 4f;

    private float nextChangeTime; // ���� ���� �ð�
    private Quaternion targetRotation; // ��ǥ ȸ�� ����

    public float randomScaleX;
    public float randomScaleY;
    public float randomScaleZ;

    void Awake()
    {
        InitializeObject();
    }

    void Update()
    {
        // ���� �ð��� ���� ���� �ð��� ������ ��
        if (Time.time >= nextChangeTime)
        {
            ChangeRotation();
            SetNextChangeTime();
        }

        // ȸ�� �ε巴�� ó��
        SmoothRotation();

        // ȸ�� �ӵ��� ���� �߰����� ȸ�� ����
        RotateObject();
    }

    // �ʱ� ������ ũ�� �� ��ġ ����
    void InitializeObject()
    {
        SetRandomScale();
        SetRandomPosition();
        SetNextChangeTime();
    }

    // �������� Euler ���� �����Ͽ� ��ǥ ȸ�� ����
    void ChangeRotation()
    {
        float randomRotationX = Random.Range(0f, 360f);
        float randomRotationY = Random.Range(0f, 360f);
        float randomRotationZ = Random.Range(0f, 360f);

        targetRotation = Quaternion.Euler(randomRotationX, randomRotationY, randomRotationZ);
    }

    // ������ ��ġ ���� (ī�޶��� �þ� ���� ����)
    void SetRandomPosition()
    {
        float randomPosX = Random.Range(-33f, 14f);
        float randomPosY = Random.Range(-21f, 17f);
        float randomPosZ = Random.Range(2f, 20f);

        transform.localPosition = new Vector3(randomPosX, randomPosY, randomPosZ);
    }

    // �������� ũ�� ����
    void SetRandomScale()
    {
        randomScaleX = Random.Range(minSize, maxSize);
        randomScaleY = Random.Range(minSize, maxSize);
        randomScaleZ = Random.Range(minSize, maxSize);

        transform.localScale = new Vector3(randomScaleX, randomScaleY, randomScaleZ);
    }

    // ȸ�� �ε巴�� ó��
    void SmoothRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothness * Time.deltaTime);
    }

    // ȸ�� �ӵ��� ���� �߰����� ȸ�� ����
    void RotateObject()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    // ���� ���� �ð� ����
    void SetNextChangeTime()
    {
        nextChangeTime = Time.time + Random.Range(minChangeInterval, maxChangeInterval);
    }
}
