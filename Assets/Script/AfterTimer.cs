using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class AfterTimer : MonoBehaviour
{
    private bool guardTiming = false;
    private bool allOutTiming = false;
    public float waitTime = 5f;
    public GameStartController isPlaying;
    private bool started = false;

    void Update()
    {
        if (!started && isPlaying.isPlaying())
            started = true; // 타이머 시작을 표시
        if (started && !isPlaying.isPlaying())
            StartCoroutine(SetGuardTimingTrueAfterDelay(waitTime)); // guardTiming을 true로 설정하기 위해 첫 번째 코루틴 시작
    }

    IEnumerator SetGuardTimingTrueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 첫 번째 대기
        guardTiming = true; // 첫 번째 대기 후 guardTiming을 true로 설정

        StartCoroutine(SetAllOutTimingTrueAfterDelay(waitTime)); // allOutTiming을 true로 설정하기 위해 두 번째 코루틴 시작
    }

    IEnumerator SetAllOutTimingTrueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 두 번째 대기
        allOutTiming = true; // 두 번째 대기 후 allOutTiming을 true로 설정

        StartCoroutine(ChangeSceneAfterDelay(waitTime)); // 마지막 지정된 시간 후 Scene 전환
    }
    IEnumerator ChangeSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // 추가 대기
        SceneManager.LoadScene("EndingCradit"); // 여기에 원하는 Scene 이름 입력
    } 

    public bool getGuardTiming () {
        return guardTiming;
    }
    public bool getAlloutTiming () {
        return allOutTiming;
    }
}
