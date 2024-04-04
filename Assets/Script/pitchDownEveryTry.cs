using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pitchDownEveryTry : MonoBehaviour
{
    public AudioSource audioSource; // AudioSource 컴포넌트를 할당하기 위한 변수
    public float pitchDecreaseAmount = 0.1f; // 피치를 낮출 양
    // Start is called before the first frame update
    void Start()
    {
       audioSource.pitch -= GameManager.tryNum * pitchDecreaseAmount;
    }
}
