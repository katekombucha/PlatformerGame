using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    // Стаття про Singleton:
    // https://gamedevbeginner.com/singletons-in-unity-the-right-way/
    public static ScoreManager Instance { get; private set; }
    public TextMeshProUGUI scoreText;
    private int score;

    private void Awake()
    {
        if (Instance != null && Instance != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Instance = this; 
        }
    }
    public void Start()
    {
        scoreText.text = score.ToString() + " POINTS";
    }

    public void AddPoint()
    {
        score += 1;
        scoreText.text = score.ToString() + " POINTS";
    }
}
