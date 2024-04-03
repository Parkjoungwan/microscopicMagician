using System.Collections;
using TMPro; // TextMeshPro 네임스페이스 사용
using UnityEngine;

public class GameStartController : MonoBehaviour
{
    public TextMeshProUGUI gameTextTMP; // UI TextMeshPro 컴포넌트
    public float timeLimit = 15f;
    private bool onlyOnce = false;
    private bool isGameStarted = false; // 게임이 시작되었는지 확인하는 플래그
    private IEnumerator gameTimerCoroutine; // 게임 타이머 코루틴 참조

    void Start()
    {
        gameTextTMP.text = "<color=red>If you Ready Press Space.</color>";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameStarted && !onlyOnce)
        {
            onlyOnce = true;
            StartGame();
        }
    }

    void StartGame()
    {
        isGameStarted = true;
        gameTextTMP.text = ""; // 게임 시작 시 텍스트 초기화

        // 게임 타이머 코루틴 시작
        gameTimerCoroutine = GameTimerCoroutine(timeLimit); // 15초 후 게임 리셋
        StartCoroutine(gameTimerCoroutine);
    }

    IEnumerator GameTimerCoroutine(float time)
    {
        yield return new WaitForSeconds(time);
        ResetGame(); // 제한 지난 후 게임 초기화
    }

    void ResetGame()
    {
        isGameStarted = false;
        if (gameTimerCoroutine != null)
        {
            StopCoroutine(gameTimerCoroutine); // 타이머 코루틴 정지
        }
        gameTextTMP.text = "<color=yellow>Time's Up</color>"; // 초기 메시지 표시
    }

    // 텍스트 입력이 완료되었을 때 호출할 메서드
    public void CompleteTextEntry()
    {
        if (isGameStarted)
        {
            ResetGame(); // 텍스트 입력 완료 시 게임 초기화
        }
    }

    public bool isPlaying()
    {
        return isGameStarted;
    }

    public void setPlaying()
    {
        isGameStarted = false;
        if (gameTimerCoroutine != null)
        {
            StopCoroutine(gameTimerCoroutine); // 타이머 코루틴 정지
        }
    }
}
