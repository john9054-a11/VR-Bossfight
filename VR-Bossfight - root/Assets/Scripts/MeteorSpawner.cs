using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using System.Collections;
public class MeteorSpawner : MonoBehaviour
{

    public GameObject meteorPrefab;
    public GameObject popupMessage;

    

    public float spawnInterval = 1f;
    public Transform[] spawnPoints;

    private bool isSpawning = false;

    private void Start()
    {
        StartSpawning();
      //  InvokeRepeating(nameof(SpawnMeteor), 1f, spawnInterval);
    }


  
    public void StartSpawning()
    {
        Debug.Log("StartSpawning kördes");


        if (isSpawning) return;

        isSpawning = true;

        if(popupMessage != null)
        {
            StartCoroutine(ShowPopup());
        }

        InvokeRepeating(nameof(SpawnMeteor), 1f, spawnInterval);


        /*
        if (spawnPoints.Length == 0) return;

        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];
        
        Instantiate(meteorPrefab, point.position, Quaternion.identity);
        */


    }


    public void StopSpawning()
    {
        isSpawning = false;
        CancelInvoke(nameof(SpawnMeteor));

    }


    public void SpawnMeteor()
    {
        /*if(popupMessage != null)
        {
            StartCoroutine(ShowPopup());
        }*/
        Debug.Log("Spawnmeteor körs");


        if (!isSpawning) return;

        if (spawnPoints.Length == 0)
            return;

        Transform point = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(meteorPrefab, point.position, Quaternion.identity);
        /*
        if(popupMessage != null)
        {
            StartCoroutine(ShowPopup());

        }
        */
    }


    private IEnumerator ShowPopup()
    {
        popupMessage.SetActive(true);

        yield return new WaitForSeconds(5f);

        popupMessage.SetActive(false);
    }






}
