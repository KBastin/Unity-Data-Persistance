using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI userNameInput;

    [SerializeField]
    private TextMeshProUGUI topScoreText;

    private void Start()
    {
        var currentTop = GameManager.Instance.CurrentTopScore;
        if (!string.IsNullOrEmpty(currentTop?.Name) && currentTop?.Score > 0)
        {
            topScoreText.text = $"Top score by: {currentTop.Name} ({currentTop.Score} points)";
        }
        else
        {
            topScoreText.text = string.Empty;
        }
    }

    public void StartNewGame()
    {
        GameManager.Instance.UserName = userNameInput.text;
        SceneManager.LoadScene(1);
    }

    public void ExitApplication()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
