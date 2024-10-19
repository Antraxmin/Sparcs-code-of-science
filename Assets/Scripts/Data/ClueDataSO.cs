using UnityEngine;

[CreateAssetMenu(fileName = "NewClueData", menuName = "Clue Data", order = 51)]
public class ClueDataSO : ScriptableObject
{
    public string clueName;         // 단서 이름
    public int clueNumber;          // 단서 번호
    public string clueDescription;  // 단서 설명
    public string quizQuestion;     // 퀴즈 문제
    public string[] choices = new string[4];  // 4개의 선택지
    public int correctAnswerIndex;  // 정답 인덱스 (0~3)
    public string explanation;      // 해설
}
