using TMPro;
using UnityEngine;

public class HighScoreSync : MonoBehaviour
{
    [SerializeField]
    private TMP_Text m_Text;

    void Awake()
    {
        GameManager.Instance.OnHighScoreChanged += HandleScoreChanged;
        HandleScoreChanged(GameManager.Instance.HighScore);
    }

    private void HandleScoreChanged(float highScore)
    {
        m_Text.text = highScore.ToString("f0");
    }

}
