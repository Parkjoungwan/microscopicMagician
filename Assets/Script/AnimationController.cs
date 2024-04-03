using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator; // Animator 컴포넌트에 대한 참조

    void Start()
    {
        animator = GetComponent<Animator>(); // 시작할 때 Animator 컴포넌트를 가져옵니다.
        animator.Play("2", 0, 0.0f); // 첫 번째 Sprite에서 애니메이션을 멈춥니다.
        animator.speed = 0; // 애니메이션을 멈추기 위해 속도를 0으로 설정
    }

    void Update()
    {
        // 여기에서는 예를 들어 사용자가 스페이스바를 누르는 조건을 사용합니다.
        // 실제 게임에서는 이 부분을 원하는 특정 조건으로 대체해야 합니다.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.speed = 1; // 애니메이션을 다시 재생하기 위해 속도를 1(기본값)로 설정
        }
    }
}
