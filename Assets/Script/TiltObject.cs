using UnityEngine;

public class TiltObject : MonoBehaviour
{
    public float tiltAngle = 20f; // 회전할 각도
    private bool started = false;
    public GameStartController gameStartController;


    void Update()
    {
        if (!started && gameStartController.isPlaying())
            started = true;
        if (started && !gameStartController.isPlaying())
            Tilt();
    }

    void Tilt()
    {
        // 객체를 z축 기준으로 tiltAngle만큼 회전
        transform.rotation = Quaternion.Euler(0, 0, tiltAngle);
    }
}
