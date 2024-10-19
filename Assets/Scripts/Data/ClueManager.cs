using UnityEngine;
using TMPro;             
using UnityEngine.UI;     

public class ClueManager : MonoBehaviour
{
    public GameObject clueModalPanel;           // 모달 패널
    public TextMeshProUGUI clueDescriptionText;     // 단서 설명
    public TextMeshProUGUI quizQuestionText;        // 퀴즈 질문
    public Button[] choiceButtons = new Button[4];          // 4개의 선택지 버튼
    public TextMeshProUGUI explanationText;         // 해설 텍스트 

    private int correctAnswerIndex;    // 정답 인덱스

    void Start()
    {
        clueModalPanel.SetActive(false);        // 처음에는 패널을 비활성화
        explanationText.gameObject.SetActive(false);        // 해설 텍스트 비활성화
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
            explanationText.text = explanation; // 해설 표시 
            explanationText.gameObject.SetActive(true); // 해설 텍스트 활성화
        }
        else
        {
            Debug.Log("틀렸습니다. 다시 시도하세요.");
        }
    }

    // 단서 모달 패널을 숨기는 함수
    public void HideClueModal()
    {
        clueModalPanel.SetActive(false);  // 모달 비활성화
    }
}
