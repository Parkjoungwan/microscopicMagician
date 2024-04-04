using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeOutToScene : MonoBehaviour
{
    public float fadeOutTime = 2.0f;
    private CanvasGroup canvasGroup;
    public scrollCheck scrollCheck;

    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    void Update()
    {
        if (scrollCheck.getOnMiddle())
            StartCoroutine(FadeToScene());
    }

    IEnumerator FadeToScene()
    {
        float rate = 1.0f / fadeOutTime;
        float progress = 0.0f;

        while (progress < 1.0)
        {
            canvasGroup.alpha = 1.0f - progress; // 페이드 아웃
            progress += rate * Time.deltaTime;
            yield return null;
        }

        canvasGroup.alpha = 0; // 완전히 투명해지면
        if (GameManager.playerScore == 0)
            SceneManager.LoadScene("Epilogue1");
        else if (GameManager.playerScore == 1)
            SceneManager.LoadScene("Epilogue2");
        else
            SceneManager.LoadScene("Epilogue3");
    }
}
