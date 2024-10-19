using UnityEngine;
using UnityEngine.UI; // UI를 위한 네임스페이스
using UnityEngine.SceneManagement; // 씬 관리를 위한 네임스페이스

public class StartButtonController : MonoBehaviour
{
    public Button startButton; // 시작 버튼을 위한 변수

    void Start()
    {
        // 버튼에 클릭 이벤트 등록
        startButton.onClick.AddListener(OnStartButtonClick);
    }

    // 시작 버튼 클릭 시 호출될 메서드
    void OnStartButtonClick()
    {
        // ExplanationScene으로 씬 전환
        SceneManager.LoadScene("ExplanationScene");
    }
}
