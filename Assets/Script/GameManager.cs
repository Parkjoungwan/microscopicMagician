using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerScore = 0; // 스태틱 변수 추가
    public static int tryNum = 0;

    public static void ResetScore() // 점수 초기화 메서드
    {
        playerScore = 0;
    }
}
