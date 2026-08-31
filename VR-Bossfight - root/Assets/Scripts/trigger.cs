using UnityEngine;

public class trigger : MonoBehaviour
{
    bool down = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(!down && Input.GetAxis("XRI_Right_Trigger")> 0.9f)
        {

            Debug.LogWarning("TRIGGERED RIGHT");
            down = true;

        }

        if(down && Input.GetAxis("XRI_Right_Trigger")< 0.1f)
        {

            down = false;

        }
        


    }
}
