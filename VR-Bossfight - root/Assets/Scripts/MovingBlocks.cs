using UnityEngine;

public class MovingBlocks : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float rotationSpeed = 8f;

    private Transform player;


    private void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");

        if(playerObj != null)
        {
            player = playerObj.transform;
        }


    }

    private void Update()
    {
        if (player == null) return;


        Vector3 direction = (player.position - transform.position).normalized;

        transform.position += direction * moveSpeed * Time.deltaTime;

        if (direction != Vector3.zero)
        {

        
           Quaternion lookRotation = Quaternion.LookRotation(direction);
           transform.rotation = Quaternion.Slerp(transform.rotation,
               lookRotation, rotationSpeed * Time.deltaTime);
        }

    }


    private void OnCollisionEnter(Collision collision)
    {
       

        if (collision.gameObject.CompareTag("Player"))
        {
           
        
           PlayerHealth ph = collision.gameObject.GetComponentInParent<PlayerHealth>();
 
           if (ph != null)
           {
               ph.TakeDamage(1);
           }

            Destroy(gameObject);
  
        }
        
    }


}
