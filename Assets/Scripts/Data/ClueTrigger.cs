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
    public Image bellIcon;  // 플레이어 머리 위 이미지 
    private ClueManager clueManager;

    public GameObject icon;  
    public Transform player;  
    public Vector3 iconOffset = new Vector3(0, 1, 0); 
    public float blinkInterval = 0.02f;  // 아이콘 깜빡이는 시간 간격
    private Coroutine blinkCoroutine;  // 깜빡임 효과를 위한 코루틴

    private bool dialogueStarted = false;  // 대화 시작 여부
    private int currentDialogueIndex = 0;  // 현재 대화 인덱스
    private Coroutine typingCoroutine;  // 타이핑 효과 코루틴

    void Start()
    {
        clueManager = FindObjectOfType<ClueManager>();
        dialoguePanel.SetActive(false);  // 대화 패널 비활성화
        icon.SetActive(false);  //  아이콘 숨김
        getButton.gameObject.SetActive(false);  // 얻기 버튼 비활성화
        bellIcon.gameObject.SetActive(false);  // 이미지 비활성화
    }

    // 플레이어가 범위에 들어왔을 때
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // 단서에 해당하는 이미지를 설정
            bellIcon.sprite = clueData.clueIcon;
            // bellIcon.gameObject.SetActive(true);  
            getButton.gameObject.SetActive(true);  // 얻기 버튼 활성화

            // 아이콘을 플레이어 머리 위에 배치
            icon.SetActive(true); 
            icon.transform.position = player.position + iconOffset;
            if (blinkCoroutine == null)  // 코루틴 실행
            {
                blinkCoroutine = StartCoroutine(BlinkIcon());
            }
        }
    }

    // 플레이어가 범위를 벗어났을 때
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (blinkCoroutine != null)  // 코루틴 중지
            {
                StopCoroutine(blinkCoroutine);
                blinkCoroutine = null;
            }
            bellIcon.gameObject.SetActive(false);  // 이미지 비활성화
            getButton.gameObject.SetActive(false);  // 얻기 버튼 비활성화
            dialoguePanel.SetActive(false);  // 대화 패널 비활성화
            dialogueStarted = false;  // 대화 상태 초기화
            currentDialogueIndex = 0;  // 대화 인덱스 초기화
            icon.SetActive(false); 
        }
    }

    // 얻기 버튼을 눌렀을 때 호출되는 함수
    public void OnGetButtonClicked()
    {
        if (!dialogueStarted)
        {
            dialogueStarted = true;
            dialoguePanel.SetActive(true);
            StartDialogue();  // 첫 대화 출력
        }
        else
        {
            if (currentDialogueIndex < clueData.dialogues.Length - 1)
            {
                currentDialogueIndex++;
                StartDialogue();  // 다음 대화 출력
            }
            else
            {
                dialoguePanel.SetActive(false);
                getButton.gameObject.SetActive(false);
                bellIcon.gameObject.SetActive(false); // 이미지 비활성화
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

    // 대화 텍스트를 타이핑 효과로 출력
    private void StartDialogue()
    {
        if (typingCoroutine != null)
        {
            StopCoroutine(typingCoroutine);  // 기존 타이핑 효과 중단
        }
        typingCoroutine = StartCoroutine(TypeDialogue(clueData.dialogues[currentDialogueIndex]));
    }

    // 한 글자씩 대화 출력하는 코루틴 함수
    private IEnumerator TypeDialogue(string dialogue)
    {
        dialogueText.text = "";  // 기존 텍스트 초기화
        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;                // 한 글자씩 추가
            yield return new WaitForSeconds(0.05f);  // 각 글자 사이의 지연 시간 
        }
    }

    // 아이콘을 깜빡임을 위한 코루틴
    IEnumerator BlinkIcon()
    {
        while (true)
        {
            icon.SetActive(!icon.activeSelf);        // 아이콘의 활성화 상태 반전 
            yield return new WaitForSeconds(blinkInterval);  
        }
    }
}