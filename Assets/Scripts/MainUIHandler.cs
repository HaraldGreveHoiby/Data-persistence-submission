using UnityEngine;
using UnityEngine.UI;

public class MainUIHandler : MonoBehaviour
{

    public Text bestScoreText;
    void Start()
    {
        if (!string.IsNullOrEmpty(SaveManager.Instance.highScoreHolderName))
        {
            string highScoreHolderName = SaveManager.Instance.highScoreHolderName;
            int highScore = SaveManager.Instance.highScore;
            bestScoreText.text = $"Best score: {highScoreHolderName}: {highScore}";
        }
        else
        {
            bestScoreText.text = "No current high score";
        }
        
    }
}
