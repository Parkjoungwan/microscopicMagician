using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour
{
    public float fadeInTime = 2.0f; // 페이드 인하는데 걸리는 시간
    private CanvasGroup canvasGroup;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeInRoutine());
    }

    IEnumerator FadeInRoutine()
    {
        // 알파 값을 0에서 시작하여 점차적으로 1로 변경
        float startTime = Time.time;
        while (Time.time - startTime < fadeInTime)
        {
            canvasGroup.alpha = (Time.time - startTime) / fadeInTime;
            yield return null;
        }

        canvasGroup.alpha = 1; // 최종적으로 완전 불투명하게 설정
    }
}
