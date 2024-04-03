using UnityEngine;

public class MoveSpriteUpward : MonoBehaviour
{
    public float targetHeight = 5f; // 올라갈 최종 높이
    public float moveSpeed = 0.1f; // 이동 속도
    private float currentVelocity; // 현재 속도 (SmoothDamp 사용)
    private Vector3 targetPosition; // 목표 위치
    private bool startMoving = false; // 움직임 시작 조건

    void Start()
    {
        // 초기 목표 위치 설정 (현재 위치에서 targetHeight만큼 위)
        targetPosition = new Vector3(transform.position.x, transform.position.y + targetHeight, transform.position.z);
    }

    void Update()
    {
        // 특정 조건 체크 (예: 스페이스바 누름)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startMoving = true;
        }

        // 움직임 시작
        if (startMoving)
        {
            // 현재 위치에서 목표 위치로 SmoothDamp 함수를 사용해 부드럽게 이동
            float newYPosition = Mathf.SmoothDamp(transform.position.y, targetPosition.y, ref currentVelocity, moveSpeed);
            transform.position = new Vector3(transform.position.x, newYPosition, transform.position.z);

            // 목표 위치에 도달하면 움직임 중지
            if (Mathf.Abs(transform.position.y - targetPosition.y) < 0.01f)
            {
                startMoving = false; // 추가 움직임을 멈추도록 설정
                transform.position = targetPosition; // 위치를 목표 위치로 정확히 설정하여 미세한 오차를 제거
            }
        }
    }
}
