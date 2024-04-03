using UnityEngine;

public class AnimationActivator : MonoBehaviour
{
    public GameObject animationObject; // 애니메이션을 포함하는 객체에 대한 참조
    public TypingEffect firstPageObject; // 읽어야할 지문 객체
    public GameStartController isPlaying;
    public bool toggle = false;

    void Start()
    {
        animationObject.SetActive(!animationObject.activeSelf);
    }
    void Update()
    {
        if (firstPageObject.getFirstPageClear() && !toggle)
        {
            toggle = true;
            animationObject.SetActive(!animationObject.activeSelf);
        }
        if (!isPlaying.isPlaying())
        {
            animationObject.SetActive(false);
        }
    }
}
