using UnityEngine;

public class AnimationActivator : MonoBehaviour
{
    public GameObject animationObject; // 애니메이션을 포함하는 객체에 대한 참조

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 특정 조건, 예를 들어 스페이스바를 눌렀을 때
        {
            // GameObject의 활성화 상태를 토글합니다.
            animationObject.SetActive(!animationObject.activeSelf);
        }
    }
}
