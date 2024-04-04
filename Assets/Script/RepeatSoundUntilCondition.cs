using UnityEngine;

public class RepeatSoundUntilCondition : MonoBehaviour
{
    private bool started = false;
    public GameStartController gameStartController;
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource 컴포넌트를 가져옵니다.
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!started && gameStartController.isPlaying())
            audioSource.Play();
        if (started && !gameStartController.isPlaying())
            audioSource.Stop();
    }
}
