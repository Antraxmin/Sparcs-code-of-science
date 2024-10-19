// using UnityEngine;

// public class ClueTrigger : MonoBehaviour
// {
//     public ClueDataSO clueData;  // Scriptable Object로 단서 데이터 관리
//     private ClueManager clueManager;

//     void Start()
//     {
//         clueManager = FindObjectOfType<ClueManager>();
//     }

//     void OnMouseDown()
//     {
//         // 터치한 단서의 설명, 퀴즈 정보, 해설 전달
//         clueManager.ShowClueModal(
//             clueData.clueDescription, 
//             clueData.quizQuestion, 
//             clueData.choices, 
//             clueData.correctAnswerIndex, 
//             clueData.explanation
//         );
//     }
// }

using UnityEngine;

public class ClueTrigger : MonoBehaviour
{
    public ClueDataSO clueData;  // Scriptable Object로 단서 데이터 관리
    private ClueManager clueManager;

    void Start()
    {
        clueManager = FindObjectOfType<ClueManager>();
    }

    // 플레이어가 단서 위치에 도달했을 때 모달을 표시
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            clueManager.ShowClueModal(
                clueData.clueDescription, 
                clueData.quizQuestion, 
                clueData.choices, 
                clueData.correctAnswerIndex, 
                clueData.explanation
            );
        }
    }

    // 플레이어가 단서 위치에서 벗어나면 모달을 닫음
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            clueManager.HideClueModal();  // 모달 닫기
        }
    }
}
