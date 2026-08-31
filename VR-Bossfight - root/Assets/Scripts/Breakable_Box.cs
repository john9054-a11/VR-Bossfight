using UnityEngine;

public class Breakable_Box : MonoBehaviour
{
    private bool isBroken = false;

    public GameObject brokenBoxPrefab;


    private void OnCollisionEnter(Collision collision)
    {
        if (isBroken) return;

        if (collision.gameObject.CompareTag("Weapon"))
        {
            Break();
        }
    }

    private void Break()
    {
        if (isBroken) return;
        isBroken = true;

        if (brokenBoxPrefab != null)
        {
            ScoreManager.Instance.AddScore(10);

            Instantiate(
                brokenBoxPrefab, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }


}
