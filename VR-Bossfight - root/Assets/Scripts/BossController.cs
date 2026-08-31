using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BossController : MonoBehaviour
{
    public Transform spawnPoint;
   
    public Animator animator;


    // För bossens liv per phase och HealthBar
    public int maxTotalHits = 9;

    public int phaseHits = 0;
    public int totalHit = 0;


    public Slider bossHealthUI;

    // Värden för funktioner som damage och rörelse
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    public float moveSpeed = 2f;

    private float lastAttackTime;
    public int damage = 1;

    private Transform player;

    private bool inFight = false;
    private bool canTakeDamage = true;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        transform.position = spawnPoint.position;
        gameObject.SetActive(false);


        bossHealthUI.maxValue = maxTotalHits;
        bossHealthUI.value = maxTotalHits;

      
    }


    void Update()
    {
        
        if (!inFight || player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);

        if (dist > attackRange)
        {
            transform.LookAt(player);

            transform.position = Vector3.MoveTowards(
                transform.position,
                player.position,
                moveSpeed * Time.deltaTime);
        }


        //if (inFight && player != null) { 

        float dist2 = Vector3.Distance(transform.position, player.position);

            if (dist2 <= attackRange)
            {
                if (Time.time - lastAttackTime > attackCooldown)
                {
                    AttackPlayer();
                    lastAttackTime = Time.time;

                }

            }

        //}

        Vector3 direction = player.position - transform.position;
        direction.y = 0;

        Quaternion targetRotation = Quaternion.LookRotation(direction);

        transform.rotation = targetRotation * Quaternion.Euler(0, -90, 0);

    }

    void AttackPlayer()
    {
        Debug.Log("Boss attacks player");
        animator.SetTrigger("Attack");
    }
    

    public void SpawnBoss()
    {
        inFight = false;
        canTakeDamage = true;

        gameObject.SetActive(true);
        transform.position = spawnPoint.position;
    }


    public void StartFight()
    {
        inFight = true;

    }

    public void TakeHit()
    {
        if (!canTakeDamage)
            return;

        canTakeDamage = false;
        Invoke(nameof(ResetHit), 0.4f);

        totalHit++;
        phaseHits++;

        Debug.Log($"Boss HP:  { totalHit} / { maxTotalHits}");

        //  canTakeDamage = false;
        // Invoke(nameof(EnableDamage), 0.5f);

        bossHealthUI.value = maxTotalHits - totalHit;


        if(phaseHits >= 3)
        {
            phaseHits = 0;
            EndPhase();
        }

        if(totalHit >= maxTotalHits)
        {
            Die();
        }

    }


    public void DealDamageToPlayer()
    {
        Debug.Log("Boss axe hit");
        if(player != null)
        {
            PlayerHealth ph = player.GetComponent<PlayerHealth>();

            if(ph != null)
            {
                ph.TakeDamage(damage);
            }
        }

    }

    void ResetHit()
    {
        canTakeDamage = true;
    }


    public void EnableDamage()
    {
        canTakeDamage = true;
    }


    void EndPhase()
    {
        inFight = false;
        canTakeDamage = false;
        transform.position = spawnPoint.position;

        GameManager.instance.StartMeteorPhase();

        Debug.Log("Phase ended -> Meteor rain again");
    }

    void Die()
    {
        Debug.Log("Boss Dead");
        gameObject.SetActive(false);

        ScoreManager.Instance.AddScore(150);
    }


}
