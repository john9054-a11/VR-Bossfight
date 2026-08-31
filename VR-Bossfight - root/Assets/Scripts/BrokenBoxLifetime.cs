using UnityEngine;

public class BrokenBoxLifetime : MonoBehaviour
{
    public float destroyTime = 5f;



    private void Start()
    {
        foreach(Rigidbody rb in GetComponentsInChildren<Rigidbody>())
        {
            rb.AddExplosionForce(300f, transform.position, 3f);
        }


        Destroy(gameObject, destroyTime);

    }





}
