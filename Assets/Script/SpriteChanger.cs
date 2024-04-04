using UnityEngine;

public class SpriteChanger : MonoBehaviour
{
    public Sprite SpriteColor;
    public Sprite SpriteGray;
    public GameStartController playController;

    void Update()
    {
        if (playController.isPlaying())
        {
            GetComponent<SpriteRenderer>().sprite = SpriteGray; // Sprite 교체
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = SpriteColor; // Sprite 교체
        }
    }
}
