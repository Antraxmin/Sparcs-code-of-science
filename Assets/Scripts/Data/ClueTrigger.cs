using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClueTrigger : MonoBehaviour
{
    public ClueDataSO clueData;  // Scriptable Object로 단서 데이터 관리
    public GameObject dialoguePanel;  // 대화 패널
    public TextMeshProUGUI dialogueText;  // 대화 텍스트
    public Button getButton;  // 얻기 버튼
    private ClueManager clueManager;

    private int currentDialogueIndex = 0;  // 현재 대화 인덱스
    private Coroutine typingCoroutine;  // 타이핑 효과 코루틴

    void Start()
    {
        clueManager = FindObjectOfType<ClueManager>();
        dialoguePanel.SetActive(false);  // 대화 패널 비활성화
        getButton.gameObject.SetActive(false);  // 얻기 버튼 비활성화
    }

    // 플레이어가 범위에 들어왔을 때
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialoguePanel.SetActive(true);  // 대화 패널 활성화
            getButton.gameObject.SetActive(true);  // 얻기 버튼 활성화
            StartDialogue();  // 대화 초기화
        }
    }

    // 플레이어가 범위를 벗어났을 때
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialoguePanel.SetActive(false);  // 대화 패널 비활성화
            getButton.gameObject.SetActive(false);  // 얻기 버튼 비활성화
            currentDialogueIndex = 0;  // 대화 인덱스 초기화
        }
    }

    // 얻기 버튼을 눌렀을 때 호출되는 함수
    public void OnGetButtonClicked()
    {
        if (currentDialogueIndex < clueData.dialogues.Length - 1)
        {
            currentDialogueIndex++;
            StartDialogue();  // 다음 대화 시작
        }
        else
        {
            dialoguePanel.SetActive(false);
            getButton.gameObject.SetActive(false);
            clueManager.ShowClueModal(
                clueData.clueDescription,
                clueData.quizQuestion,
                clueData.choices,
                clueData.correctAnswerIndex,
                clueData.explanation
            );
        }
    }

    // 대화 텍스트를 타이핑 효과로 출력
    private void StartDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);  // 코루틴이 실행 중이면 중단
        }
        typingCoroutine = StartCoroutine(TypeDialogue(clueData.dialogues[currentDialogueIndex]));
    }

    // 한 글자씩 대화 출력하는 코루틴 함수
    private IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";  // 기존 텍스트 초기화
        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;  // 한 글자씩 추가
            yield return new WaitForSeconds(0.05f);  // 각 글자 사이의 지연 시간 
        }
    }
}

