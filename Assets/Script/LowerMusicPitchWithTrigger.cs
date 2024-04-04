using UnityEngine;

public class LowerMusicPitchWithTrigger : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource 컴포넌트를 할당하기 위한 변수
    public GameStartController gameStartController;
    public float pitchDecreaseAmount = 0.1f; // 피치를 낮출 양
    private bool started = false;

    void Update()
    {
        if (!started && gameStartController.isPlaying())
            started = true;
        if (gameStartController.isPlaying())
        {
            // AudioSource의 피치를 낮춥니다.
            audioSource.pitch -= pitchDecreaseAmount;
            // 선택적: 피치가 너무 낮아지는 것을 방지합니다.
            if (audioSource.pitch < 0.45f)
            {
                audioSource.pitch = 0.5f; // 피치의 최소값을 설정합니다.
            }
        }
        if (started && !gameStartController.isPlaying())
        {
            audioSource.Stop();
            this.enabled = false;
        }

    }
}
