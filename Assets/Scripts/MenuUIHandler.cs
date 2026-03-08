using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInputField;
    public TMP_Text highScoreText;
    void Start()
    {
        int highScore = SaveManager.Instance.highScore;
        string highScoreHolderName = SaveManager.Instance.highScoreHolderName;
        highScoreText.text = $"{highScoreHolderName}: {highScore}";
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
        string playerName = nameInputField.text;
        SaveManager.Instance.playerName = playerName;
    }
}
