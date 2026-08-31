using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager Instance;

    public int score = 0;
    public TextMeshProUGUI scoreText;


    private void Start()
    {
        scoreText.text = "Score : 0";

    }


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }


    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "Score:" + score;

      //  GameManager.instance.CheckWin(score);
    }


}
