using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    [Header("Movement")]
    public float moveDistance = 3f;
    public float speed = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool playerOnPlatform = false;


    private void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.up * moveDistance;
    }


    private void Update()
    {
        if (!playerOnPlatform) return;

        transform.position = Vector3.MoveTowards(
        transform.position, targetPos, speed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, targetPos) < 0.01) 
        { 
            targetPos = (targetPos == startPos) ? startPos + Vector3.up * moveDistance : startPos;
        
        
        }


    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOnPlatform = false;
        }
    }

    // NEDAN: Använde denna till att spelaren följer med platform vid behov

    /* private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        collision.transform.SetParent(transform);
    }
}

private void OnCollisionExit(Collision collision)
{
    if (collision.gameObject.CompareTag("Player"))
    {
        collision.transform.SetParent(null);
    }
}   */

}
