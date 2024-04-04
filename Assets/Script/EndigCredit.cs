using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // TextMeshPro 네임스페이스 추가

public class EndigCredit : MonoBehaviour
{
    public float speed = 20f; // 상승 속도 조절
    public scrollCheck scrollCheck;

    void Update()
    {
        if (transform.position.y <= 3)
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (transform.position.y >= 3 && Input.GetKeyDown(KeyCode.Space)) // 적절한 값으로 조절하세요.
        {
            scrollCheck.setOnMiddle();
        }
    }
}
