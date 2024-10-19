using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExplanationPanelController : MonoBehaviour
{
    public TextMeshProUGUI explanationText1; // 첫 번째 설명 TextMeshProUGUI
    public TextMeshProUGUI explanationText2; // 두 번째 설명 TextMeshProUGUI
    public Button nextButton; // 버튼 컴포넌트

    private int currentIndex = 0; 

    void Start()
    {
        // 첫 번째 텍스트로 시작
        ShowExplanation(currentIndex);
        
        // 버튼 클릭 이벤트 리스너 추가
        nextButton.onClick.AddListener(NextExplanation);
    }

    void ShowExplanation(int index)
    {
        // 현재 인덱스에 따라 텍스트 표시
        if (index == 0)
        {
            explanationText1.gameObject.SetActive(true);
            explanationText2.gameObject.SetActive(false);
        }
        else if (index == 1)
        {
            explanationText1.gameObject.SetActive(false);
            explanationText2.gameObject.SetActive(true);
        }
    }

    void NextExplanation()
    {
        // 현재 인덱스가 설명의 개수보다 작은 경우
        if (currentIndex < 1)
        {
            currentIndex++; // 다음 인덱스 증가
            ShowExplanation(currentIndex); // 텍스트 업데이트
        }
        else
        {
            // 모든 설명이 끝난 경우, 패널을 닫거나 다음 씬으로 이동하는 동작 추가
            SceneManager.LoadScene("RunaScene");
            Debug.Log("설명이 끝났습니다.");
            // 여기에 패널을 닫거나 다음 씬으로 이동하는 코드 추가
        }
    }
}
