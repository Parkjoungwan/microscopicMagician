using UnityEngine;
using TMPro;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float timeRemaining = 30f;
    private bool timerIsRunning = false;
    public GameStartController isPlaying;

    void Start()
    {
        timerText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (isPlaying.isPlaying())
        {
            StartTimer();
        }

        if (!isPlaying.isPlaying() && timerIsRunning)
        {
            StopTimer();
        }

        // 타이머가 실행 중일 때만 시간 감소
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                StopTimer(); // 타이머 종료
            }
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
        timerText.gameObject.SetActive(true);
        UpdateTimerDisplay();
    }

    public void StopTimer()
    {
        timerIsRunning = false;
        timeRemaining = 30f; // 타이머 리셋 (필요에 따라 조정)
        timerText.gameObject.SetActive(false); // 타이머 숨기기 (필요에 따라)
        // 필요한 추가 종료 로직을 여기에 구현
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
