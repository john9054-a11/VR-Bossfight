using UnityEngine;

public class Points_FromBrokenBox : MonoBehaviour
{

    private bool collected = false;


    private void OnTriggerEnter(Collider other)
    {
        if (collected) return;

        if (other.CompareTag("PlayerHand"))
        {
            collected = true;

            ScoreManager.Instance.AddScore(1);

            Destroy(gameObject);

        }
    }


}
