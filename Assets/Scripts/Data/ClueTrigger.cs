// using UnityEngine;

// public class ClueTrigger : MonoBehaviour
// {
//     public ClueDataSO clueData;  // Scriptable Object로 단서 데이터 관리
//     private ClueManager clueManager;

//     void Start()
//     {
//         clueManager = FindObjectOfType<ClueManager>();
//     }

//     // 플레이어가 단서 위치에 도달했을 때 모달을 표시
//     void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             clueManager.ShowClueModal(
//                 clueData.clueDescription, 
//                 clueData.quizQuestion, 
//                 clueData.choices, 
//                 clueData.correctAnswerIndex, 
//                 clueData.explanation
//             );
//         }
//     }

//     // 플레이어가 단서 위치에서 벗어나면 모달을 닫음
//     void OnTriggerExit2D(Collider2D other)
//     {
//         if (other.CompareTag("Player"))
//         {
//             clueManager.HideClueModal();  // 모달 닫기
//         }
//     }
// }

using UnityEngine;

public class ClueTrigger : MonoBehaviour
{
    public ClueDataSO clueData;  // Scriptable Object로 단서 데이터 관리
    public GameObject dialoguePanel;        // 대화 패널
    public GameObject getButton;            // 얻기 버튼
    private ClueManager clueManager;
    private bool isPlayerInRange = false;  // 플레이어가 범위 내에 있는지 체크

    void Start()
    {
        // ClueManager를 찾아서 참조
        clueManager = FindObjectOfType<ClueManager>();
        dialoguePanel.SetActive(false);          // 대화 패널 비활성화
        getButton.SetActive(false);             // 얻기 버튼 비활성화
    }

    // 플레이어가 범위에 들어왔을 때
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // 플레이어 태그로 감지
        {
            isPlayerInRange = true;
            dialoguePanel.SetActive(true);  // 대화 패널 활성화
            getButton.SetActive(true);  // 얻기 버튼 활성화
        }
    }

    // 플레이어가 범위를 벗어났을 때
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialoguePanel.SetActive(false);  // 대화 패널 비활성화
            getButton.SetActive(false);  // 얻기 버튼 비활성화
        }
    }

    // 얻기 버튼을 눌렀을 때 호출되는 함수
    public void OnGetButtonClicked()
    {
        if (isPlayerInRange)
        {
            dialoguePanel.SetActive(false);  // 대화 패널 비활성화
            getButton.SetActive(false);  // 얻기 버튼 비활성화
            // ClueManager를 통해 단서 모달을 띄움
            clueManager.ShowClueModal(
                clueData.clueDescription,
                clueData.quizQuestion,
                clueData.choices,
                clueData.correctAnswerIndex,
                clueData.explanation
            );
        }
    }
}
