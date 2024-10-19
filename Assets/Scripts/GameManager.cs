using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;   // 싱글톤 인스턴스
    public float life = 5f;               // 초기 수명 - 5개의 하트
    private const float maxLife = 5f;     // 최대 수명

    void Awake()
    {
        // 중복 방지를 위한 싱글톤 패턴 구현
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);      // 씬 전환 시에도 파괴되지 않도록 
        }
        else
        {
            Destroy(gameObject);            // 중복된 GameManager 파괴
        }
    }

    // 수명 감소 
    public void ReduceLife(float amount)
    {
        life -= amount;
        if (life <= 0)
        {
            life = 0;
            GameOver();  // 수명이 0이 되면 게임 종료
        }
        UpdateHearts();  // 하트 UI 업데이트 
    }

    // 수명 초기화 
    public void ResetLife()
    {
        life = maxLife;  // 수명 초기화
        UpdateHearts();  // 하트 UI 업데이트 
    }

    // 게임 종료 
    void GameOver()
    {
        Debug.Log("게임 종료");
        ResetLife();
    }

    public void UpdateHearts()
    {
    }
}