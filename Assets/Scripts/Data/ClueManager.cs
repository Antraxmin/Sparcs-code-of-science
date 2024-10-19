using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ClueManager : MonoBehaviour
{
    public GameObject clueModalPanel;           // 모달 패널
    public TextMeshProUGUI clueDescriptionText;     // 단서 설명
    public TextMeshProUGUI quizQuestionText;        // 퀴즈 질문
    public Button[] choiceButtons = new Button[4];  // 4개의 선택지 버튼
    public TextMeshProUGUI explanationText;         // 해설 텍스트 
    public Image[] heartImages;                     // 하트 이미지 배열
    public Sprite correctAnswerSprite;              // 정답일 때 초록색 이미지로 바꿀 스프라이트

    private int correctAnswerIndex;    // 정답 인덱스

    void Start()
    {
        clueModalPanel.SetActive(false);        // 처음에는 패널을 비활성화
        explanationText.gameObject.SetActive(false); // 해설 텍스트 비활성화
        UpdateHearts();                         // 처음 시작 시 하트 업데이트
    }

    // 단서 모달 패널을 띄우는 함수
    public void ShowClueModal(string clueDescription, string quizQuestion, string[] choices, int correctAnswer, string explanation)
    {
        clueModalPanel.SetActive(true);      // 패널 활성화
        explanationText.gameObject.SetActive(false); // 해설은 처음에 숨김
        clueDescriptionText.text = clueDescription;  // 단서 설명 표시 
        quizQuestionText.text = quizQuestion;        // 퀴즈 질문 표시 
        correctAnswerIndex = correctAnswer;          // 정답 인덱스 설정

        // 선택지 버튼에 텍스트 설정
        for (int i = 0; i < choices.Length; i++)
        {
            int index = i; // 로컬 변수를 사용하여 클릭 이벤트에 전달
            choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = choices[i]; // 선택지 텍스트 설정
            choiceButtons[i].onClick.RemoveAllListeners();  // 기존 리스너 제거
            choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(index, explanation));
        }
    }

    // 사용자가 선택지를 선택했을 때 호출될 함수
    void OnChoiceSelected(int selectedIndex, string explanation)
    {
        if (selectedIndex == correctAnswerIndex)
        {
            Debug.Log("정답입니다!");
            // 선택한 버튼의 이미지를 초록색으로 변경
            choiceButtons[selectedIndex].GetComponent<Image>().sprite = correctAnswerSprite;

            // 추가로 해설 표시 등을 하고 싶다면 여기에 추가
            // explanationText.text = explanation; 
            // explanationText.gameObject.SetActive(true); 
        }
        else
        {
            Debug.Log("틀렸습니다. 다시 시도하세요.");
            GameManager.instance.ReduceLife(0.5f);  // 수명 감소
            UpdateHearts();  // 수명 감소 후 하트 UI 업데이트
        }
    }

    // 단서 모달 패널을 숨기는 함수
    public void HideClueModal()
    {
        clueModalPanel.SetActive(false);  // 모달 비활성화
    }

    // 하트 UI 업데이트
    public void UpdateHearts()
    {
        float life = GameManager.instance.life;  // GameManager에서 수명 정보 가져옴
        for (int i = 0; i < heartImages.Length; i++)
        {
            if (life >= i + 1)
            {
                heartImages[i].fillAmount = 1;  // 하트 꽉 채움
            }
            else if (life > i && life < i + 1)
            {
                heartImages[i].fillAmount = 0.5f;  // 반 하트 표시
            }
            else
            {
                heartImages[i].fillAmount = 0;  // 빈 하트 표시
            }
        }
    }
}
