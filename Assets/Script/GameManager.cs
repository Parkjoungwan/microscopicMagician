using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerScore = 0; // 스태틱 변수 추가
    void Start()
    {
        ResetScore(); // 게임 시작 시 점수 초기화
    }

    public static void ResetScore() // 점수 초기화 메서드
    {
        playerScore = 0;
    }
}
