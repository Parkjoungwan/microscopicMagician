using TMPro; // TextMeshPro 네임스페이스 사용
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    public TMP_Text[] textComponents; // 두 페이지의 TextMeshPro 컴포넌트 배열
    private int currentPageIndex = 0; // 현재 페이지 인덱스
    private string originalText; // 현재 페이지의 원본 텍스트
    private string displayedText = ""; // 현재 페이지에서 화면에 표시될 텍스트
    private int charIndex = 0; // 현재 페이지에서 처리 중인 문자의 인덱스

    void Start()
    {
        // 첫 페이지의 원본 텍스트를 설정
        originalText = textComponents[currentPageIndex].text;
        UpdateTextComponent();
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            foreach (char inputChar in Input.inputString)
            {
                // 입력된 문자가 있고, charIndex가 현재 페이지의 원본 텍스트 길이보다 작을 경우에만 처리
                if (!string.IsNullOrEmpty(Input.inputString) && charIndex < originalText.Length)
                {
                    if (inputChar == originalText[charIndex]) // 입력 문자가 올바른 경우
                    {
                        displayedText += string.Format("<color=green>{0}</color>", inputChar); // 색상 적용
                        charIndex++; // 다음 문자로 이동
                    }
                    // 입력 문자가 원본 텍스트와 일치하지 않는 경우, 추가 입력을 받지 않음
                    else
                    {
                        break;
                    }
                }
            }

            // 화면에 표시될 텍스트 업데이트
            UpdateTextComponent();

            // 현재 페이지의 모든 텍스트 입력 완료 확인
            if (charIndex >= originalText.Length && currentPageIndex < textComponents.Length - 1)
            {
                // 다음 페이지로 전환
                currentPageIndex++;
                originalText = textComponents[currentPageIndex].text; // 다음 페이지의 원본 텍스트 설정
                displayedText = ""; // 표시될 텍스트 초기화
                charIndex = 0; // 인덱스 초기화
                UpdateTextComponent();
            }
        }
    }

    void UpdateTextComponent()
    {
        // 남은 텍스트와 함께 화면에 표시될 텍스트 업데이트
        textComponents[currentPageIndex].text = displayedText + originalText.Substring(charIndex);
    }
}

