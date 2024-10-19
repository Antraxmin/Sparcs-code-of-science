using UnityEngine;
using UnityEngine.UI;

public class StartModalController : MonoBehaviour
{
    public GameObject modalPanel; // 모달 패널
    public float displayDuration = 3.0f; // 문구 표시 시간

    void Start()
    {
        ShowModal();
    }

    void ShowModal()
    {
        modalPanel.SetActive(true); // 모달 패널 활성화
        // modalText.text = message; // 텍스트 설정
        Invoke("HideModal", displayDuration); // 일정 시간 후에 텍스트 숨기기
    }

    void HideModal()
    {
        modalPanel.SetActive(false); // 모달 패널 비활성화
    }
}
