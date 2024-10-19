using UnityEngine;

public class ClueTrigger : MonoBehaviour
{
    public ClueDataSO clueData;  // Scriptable Object로 단서 데이터 관리
    private ClueManager clueManager;

    void Start()
    {
        clueManager = FindObjectOfType<ClueManager>();
    }

    void OnMouseDown()
    {
        // 터치한 단서의 설명, 퀴즈 정보, 해설 전달
        clueManager.ShowClueModal(
            clueData.clueDescription, 
            clueData.quizQuestion, 
            clueData.choices, 
            clueData.correctAnswerIndex, 
            clueData.explanation
        );
    }
}
