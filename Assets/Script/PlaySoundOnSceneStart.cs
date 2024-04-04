using UnityEngine;

public class PlaySoundOnSceneStart : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource 컴포넌트를 가져옵니다.
        audioSource = GetComponent<AudioSource>();
        
        // 오디오 재생을 시작합니다.
        if(audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("AudioSource component missing on this GameObject");
        }
    }
}
