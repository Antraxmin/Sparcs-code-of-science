using UnityEngine;

[CreateAssetMenu(fileName = "NewClueData", menuName = "Clue Data", order = 51)]
public class ClueDataSO : ScriptableObject
{
    public string clueName;         // 단서 이름
    public int clueID;              // 단서 고유 ID (이것이 필요합니다)
    public string clueDescription;  // 단서 설명
    public string quizQuestion;     // 퀴즈 문제
    public string[] choices = new string[4];  // 4개의 선택지
    public int correctAnswerIndex;  // 정답 인덱스 (0~3)
    public string explanation;      // 해설
    public string[] dialogues = new string[5];  // 5개의 대화 내용
    public Sprite clueIcon;         // 단서 아이콘
}

