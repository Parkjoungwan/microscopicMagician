using TMPro; // TextMeshPro 네임스페이스 사용
using UnityEngine;

public class TypingEffect : MonoBehaviour
{
    public TMP_Text[] textComponents; // 두 페이지의 TextMeshPro 컴포넌트 배열
    private int currentPageIndex = 0; // 현재 페이지 인덱스
    private string originalText; // 현재 페이지의 원본 텍스트
    private string displayedText = ""; // 현재 페이지에서 화면에 표시될 텍스트
    private int charIndex = 0; // 현재 페이지에서 처리 중인 문자의 인덱스
    private bool firstPageClear = false;
    public GameStartController isPlaying;

    // 각 페이지의 가능한 텍스트 버전을 저장하는 배열
    private string[,] pageVersions = new string[,]
    {
        { "From the shadows, I summon the microscopic agents of darkness. Cursed souls, weave through my enemies, spreading decay and despair.", "Transform their essence into my power, and with each beat of their weakening hearts, strengthen mine." },
        { "In the unseen depths, I summon microscopic harbingers of ruin. Tiny architects of decay, invade my foes, sowing seeds of despair within.", "As their strength wanes, fueling the embers of my dark power." },
        { "Beneath the veil of reality, I invoke the microscopic sentinels of shadow. Minute warriors of blight, permeate the essence of those", "who oppose me, embedding seeds of torment. Their diminishing vigor feeds the flames of my ancient power." }
        // 여기에 더 많은 버전 추가 가능
    };

    void Start()
    {
        // 게임 시작 시 랜덤한 버전 선택
        int versionIndex = Random.Range(0, pageVersions.GetLength(0));
        // 선택된 버전의 pageOne & pageTwo 텍스트 설정
        textComponents[0].text = pageVersions[versionIndex, 0];
        textComponents[1].text = pageVersions[versionIndex, 1];

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
                        displayedText += string.Format("<color=red>{0}</color>", inputChar); // 색상 적용
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
            if (charIndex >= originalText.Length)
            {
                if (currentPageIndex < textComponents.Length - 1)
                {
                    // 다음 페이지로 전환
                    currentPageIndex++;
                    originalText = textComponents[currentPageIndex].text; // 다음 페이지의 원본 텍스트 설정
                    displayedText = ""; // 표시될 텍스트 초기화
                    charIndex = 0; // 인덱스 초기화
                    if (!firstPageClear)
                    {
                        firstPageClear = true;
                        GameManager.playerScore = 1;
                    }
                    UpdateTextComponent();
                }
                else
                {
                    GameManager.playerScore = 2;
                    isPlaying.setPlaying();
                }
            }
        }
    }

    void UpdateTextComponent()
    {
        // 남은 텍스트와 함께 화면에 표시될 텍스트 업데이트
        textComponents[currentPageIndex].text = displayedText + originalText.Substring(charIndex);
    }
    public bool getFirstPageClear()
    {
        return firstPageClear;
    }
}
