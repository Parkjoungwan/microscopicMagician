using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardEntry : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도
    public float rotationSpeed = 180f; // 회전 속도 (도/초)
    public Vector3 targetPosition; // 목표 위치
    public AfterTimer afterTimer;
    private bool hasReachedTarget = false; // 목표에 도달했는지 여부

    void Start()
    {
        // 현재 GameObject의 y와 z 좌표를 유지하면서, x 좌표만 targetPosition으로 변경하기 위해 초기화
        targetPosition = new Vector3(targetPosition.x, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (afterTimer.getGuardTiming() && !hasReachedTarget)
        {
            // 목표 위치까지 현재 위치를 선형적으로 이동시킴
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // 회전
            transform.Rotate(Vector3.forward, -rotationSpeed * Time.deltaTime);

            // 목표 위치에 도달했는지 확인
            if (transform.position == targetPosition)
            {
                hasReachedTarget = true; // 목표에 도달했으므로 이동과 회전을 멈춤
                transform.rotation = Quaternion.identity; // 선택적: 회전을 초기화하거나 특정 각도로 설정
            }
        }
    }
}