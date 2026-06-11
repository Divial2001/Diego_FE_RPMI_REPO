using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private bool isPlaying = false;

    [SerializeField]
    private float score = 0;
    public float Score
    {
        get { return score; }
        set { score = value; OnScoreChanged?.Invoke(value); }
    }

    [SerializeField]
    private float highScore = 0;
    public float HighScore
    {
        get { return highScore; }
        set { highScore = value; OnHighScoreChanged?.Invoke(value); }
    }


    public event Action<float> OnScoreChanged;
    public event Action<float> OnHighScoreChanged;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindAnyObjectByType<GameManager>();
            }
            return instance;
        }
    }
    void Awake()
    {
        if (instance == null || instance == this)
        {
            instance = this; 
            GameObject.DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (isPlaying) Score += Time.deltaTime;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        isPlaying = true;
    }

    public void EndGame()
    {
        isPlaying = false;
        SceneManager.LoadScene("MainMenu");
        HighScore = Mathf.Max(HighScore, Score);
        Score = 0;
    }

}
