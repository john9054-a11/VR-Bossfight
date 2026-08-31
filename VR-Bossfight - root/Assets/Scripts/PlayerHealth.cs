using UnityEngine;
using TMPro;


public class PlayerHealth : MonoBehaviour
{
  public static PlayerHealth Instance;

    public int maxHealth = 3;
    private int currentHealth;

    public TextMeshProUGUI healthText;


    private void Awake()
    {
        Instance = this;
    }
        
    private void Start()
    {
        currentHealth = maxHealth;
        UpdateUI();

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if(currentHealth < 0)
            currentHealth = 0;

        UpdateUI();

        Debug.Log("Game over");

        if(currentHealth == 0)
        {
            GameManager.instance.GameOver();
        }

    }

    public void UpdateUI()
    {
        if(healthText != null) 
        healthText.text = "Health:" + currentHealth;
    }
    






}
