using UnityEngine;
using UnityEngine.UI;

public class ClueManager : MonoBehaviour
{
    public GameObject clueModalPanel;  // 모달 패널
    public Text clueText;              // 단서 설명 및 퀴즈 질문
    public Button[] choiceButtons = new Button[4];  // 4개의 선택지 버튼
    private int correctAnswerIndex;    // 정답 인덱스

    void Start()
    {
        // 시작 시 패널 비활성화 상태
        clueModalPanel.SetActive(false); 
    }

    // 단서 모달 패널을 띄우는 함수
    public void ShowClueModal(string clueDescription, string quizQuestion, string[] choices, int correctAnswer)
    {
        clueModalPanel.SetActive(true);             // 패널 활성화
        clueText.text = clueDescription + "\n" + quizQuestion; // 단서 설명과 퀴즈 문제 표시
        correctAnswerIndex = correctAnswer;         // 정답 인덱스 설정

        // 선택지 버튼에 텍스트 설정
        for (int i = 0; i < choices.Length; i++)
        {
            int index = i;       // 로컬 변수를 사용하여 클릭 이벤트에 전달
            choiceButtons[i].GetComponentInChildren<Text>().text = choices[i];
            choiceButtons[i].onClick.RemoveAllListeners();      // 기존 리스너 제거
            choiceButtons[i].onClick.AddListener(() => OnChoiceSelected(index));
        }
    }

    // 사용자가 선택지를 선택했을 때 호출될 함수
    void OnChoiceSelected(int selectedIndex)
    {
        if (selectedIndex == correctAnswerIndex)
        {
            Debug.Log("정답입니다!");
            clueModalPanel.SetActive(false);    // 정답 맞히면 패널 닫기
        }
        else
        {
            // 틀렸을때 이벤트 처리 추가해야함
            Debug.Log("틀렸습니다. 다시 시도하세요.");
        }
    }
}
