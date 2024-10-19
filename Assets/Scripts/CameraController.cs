using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public float zoomInSize = 2.0f; // 줌인 크기
    public float zoomOutSize = 5.0f; // 기본 카메라 크기
    public Button zoomOutButton; // 줌아웃 버튼

    private Vector3 targetPosition; // 카메라가 이동할 목표 위치
    private bool isZoomedIn = false; // 현재 줌인 상태인지 확인

    void Start()
    {
        zoomOutButton.gameObject.SetActive(false); // 처음에는 버튼을 비활성화
        zoomOutButton.onClick.AddListener(ZoomOut); // 버튼 클릭 시 줌아웃
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭 또는 터치 감지
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ZoomIn(touchPosition);
        }
    }

    void ZoomIn(Vector3 position)
    {
        if (!isZoomedIn)
        {
            targetPosition = new Vector3(position.x, position.y, Camera.main.transform.position.z);
            Camera.main.transform.position = targetPosition;
            Camera.main.orthographicSize = zoomInSize; // 줌인
            isZoomedIn = true;
            zoomOutButton.gameObject.SetActive(true); // 화살표 버튼 활성화
        }
    }

    void ZoomOut()
    {
        Camera.main.orthographicSize = zoomOutSize; // 줌아웃
        Camera.main.transform.position = new Vector3(0, 0, Camera.main.transform.position.z); // 카메라를 원래 위치로 복귀
        isZoomedIn = false;
        zoomOutButton.gameObject.SetActive(false); // 화살표 버튼 비활성화
    }
}
