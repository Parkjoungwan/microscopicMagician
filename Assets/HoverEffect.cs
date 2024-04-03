using UnityEngine;

public class HoverEffect : MonoBehaviour
{
    public float amplitude = 0.5f; // 움직임의 진폭(높이)
    public float frequency = 1f; // 움직임의 빈도(속도)

    private Vector3 startPos; // 시작 위치

    void Start()
    {
        startPos = transform.position; // 시작 위치를 현재 위치로 설정
    }

    void Update()
    {
        // Sin 함수를 사용하여 시간에 따라 값을 변화시키고, 이를 객체의 y 위치에 적용
        float tempPos = amplitude * Mathf.Sin(Time.time * frequency);
        transform.position = new Vector3(startPos.x, startPos.y + tempPos, startPos.z);
    }
}
