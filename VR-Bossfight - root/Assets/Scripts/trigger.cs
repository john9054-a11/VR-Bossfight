using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class trigger : MonoBehaviour
{
    bool down = false;
    public GameObject weapon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (!down && Input.GetAxis("XRI_Right_Trigger") > 0.9f)
        {
            if (weapon != null)
                Destroy(weapon); //child object i högra handen
            Debug.LogWarning("TRIGGERED RIGHT");
            down = true;


        }


        if (down && Input.GetAxis("XRI_Right_Trigger") < 0.1f)
        {

            down = false;

        }



    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer.Equals("Weapon"))
        {

        Debug.Log(other.gameObject.name + " trigger script GRAB");
        weapon = other.gameObject;


        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer.Equals("weapon"))
        {
            Debug.Log(other.gameObject.name + "lost");
            weapon = null;
        }
    }
}