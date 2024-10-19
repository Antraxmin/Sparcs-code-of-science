using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class SerafScript : MonoBehaviour
{
    public Button nextButton;

    void Start()
    {
        nextButton.onClick.AddListener(OnStartButtonClick);
    }

    void OnStartButtonClick()
    {
        SceneManager.LoadScene("EcoScene");
    }
}
