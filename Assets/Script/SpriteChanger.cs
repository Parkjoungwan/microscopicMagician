using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public Sprite SpriteColor;
    public Sprite SpriteGray;
    private bool toggle = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // 스페이스바를 눌렀을 때
        {
            if (toggle)
                GetComponent<SpriteRenderer>().sprite = SpriteGray; // Sprite 교체
            else
            {
                GetComponent<SpriteRenderer>().sprite = SpriteColor; // Sprite 교체
            }
            toggle = !toggle;
        }
    }
}
