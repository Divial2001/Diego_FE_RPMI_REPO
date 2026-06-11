using TMPro;
using UnityEngine;

public class ScoreSync : MonoBehaviour
{
    
    [SerializeField]
    private TMP_Text m_Text;

    void Awake()
    {
        GameManager.Instance.OnScoreChanged += HandleScoreChanged;
    }

    private void HandleScoreChanged(float score)
    {
        m_Text.text = score.ToString("f0");
    }
}
