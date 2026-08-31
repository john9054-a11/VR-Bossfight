using UnityEngine;

public class Weapon : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("VAPEN TRÄFFADE: " + collision.gameObject.name);


        BossController boss = collision.gameObject.GetComponent<BossController>();

        if(boss != null)
        {
            Debug.Log("Weapon träffade boss");
            boss.TakeHit();
        }

        Debug.Log("Hit: " + collision.gameObject.name);
    }

   

}

