using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public float minChangeInterval = 1f;  // 최소 변경 간격
    public float maxChangeInterval = 3f;  // 최대 변경 간격
    public float rotationSpeed = 5f;      // 회전 속도
    public float smoothness = 2f;         // 회전 부드러움 정도
    public float minSize = 0.5f;
    public float maxSize = 4f;

    private float nextChangeTime; // 다음 변경 시간
    private Quaternion targetRotation; // 목표 회전 각도

    public float randomScaleX;
    public float randomScaleY;
    public float randomScaleZ;

    void Awake()
    {
        InitializeObject();
    }

    void Update()
    {
        // 현재 시간이 다음 변경 시간을 지났을 때
        if (Time.time >= nextChangeTime)
        {
            ChangeRotation();
            SetNextChangeTime();
        }

        // 회전 부드럽게 처리
        SmoothRotation();

        // 회전 속도에 따라 추가적인 회전 적용
        RotateObject();
    }

    // 초기 무작위 크기 및 위치 설정
    void InitializeObject()
    {
        SetRandomScale();
        SetRandomPosition();
        SetNextChangeTime();
    }

    // 무작위로 Euler 각도 생성하여 목표 회전 설정
    void ChangeRotation()
    {
        float randomRotationX = Random.Range(0f, 360f);
        float randomRotationY = Random.Range(0f, 360f);
        float randomRotationZ = Random.Range(0f, 360f);

        targetRotation = Quaternion.Euler(randomRotationX, randomRotationY, randomRotationZ);
    }

    // 무작위 위치 설정 (카메라의 시야 영역 기준)
    void SetRandomPosition()
    {
        float randomPosX = Random.Range(-33f, 14f);
        float randomPosY = Random.Range(-21f, 17f);
        float randomPosZ = Random.Range(2f, 20f);

        transform.localPosition = new Vector3(randomPosX, randomPosY, randomPosZ);
    }

    // 무작위로 크기 설정
    void SetRandomScale()
    {
        randomScaleX = Random.Range(minSize, maxSize);
        randomScaleY = Random.Range(minSize, maxSize);
        randomScaleZ = Random.Range(minSize, maxSize);

        transform.localScale = new Vector3(randomScaleX, randomScaleY, randomScaleZ);
    }

    // 회전 부드럽게 처리
    void SmoothRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smoothness * Time.deltaTime);
    }

    // 회전 속도에 따라 추가적인 회전 적용
    void RotateObject()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }

    // 다음 변경 시간 설정
    void SetNextChangeTime()
    {
        nextChangeTime = Time.time + Random.Range(minChangeInterval, maxChangeInterval);
    }
}
