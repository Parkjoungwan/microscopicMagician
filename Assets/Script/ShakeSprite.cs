using System.Collections;
using UnityEngine;

public class ShakeSprite : MonoBehaviour
{
    public float shakeDuration = 0.5f; // 흔들림 지속 시간
    public float shakeMagnitude = 0.7f; // 흔들림 시작 강도

    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.localPosition;
        StartShake(); // 오브젝트 활성화 시 흔들림 시작
    }

    public void StartShake()
    {
        StartCoroutine(ShakeWithDecrease(shakeDuration, shakeMagnitude));
    }

    IEnumerator ShakeWithDecrease(float duration, float magnitude)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            float currentMagnitude = magnitude * (1 - (elapsedTime / duration)); // 시간에 따라 감소하는 강도
            Vector3 randomPoint = originalPosition + Random.insideUnitSphere * currentMagnitude;
            // Z 축 값은 원본 유지
            transform.localPosition = new Vector3(randomPoint.x, randomPoint.y, originalPosition.z);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition; // 흔들림 종료 후 원래 위치로 복귀
    }
}
