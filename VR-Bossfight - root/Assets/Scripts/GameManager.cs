using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager instance;

    public GameObject gameOverPanel;

    [Header("Game Settings")]
    public int winScore = 10;

    [Header("Phase System")]
    public float meteorPhaseTime = 35f;

    public MeteorSpawner meteorSpawner;
    public BossController boss;


    private bool gameWon = false;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        StartMeteorPhase();

        gameOverPanel.SetActive(false);
    }

    public void StartMeteorPhase()
    {
        meteorSpawner.StartSpawning();
        Invoke(nameof(StartBossPhase), meteorPhaseTime);
    }

    void StartBossPhase()
    {
        meteorSpawner.StopSpawning();
        boss.SpawnBoss();
        boss.StartFight();
    }


    public void CheckWin(int currentScore)
    {
        if (gameWon) 
            return;

        if(currentScore >= winScore)
        {
            gameWon = true;
        }


    }



    public void GameOver()
    {
        meteorSpawner.StopSpawning();

        boss.gameObject.SetActive(false);

        gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }



}
