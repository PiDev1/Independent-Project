using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject rainPrefab;

    float spawnTimer = 2f;
    float rateIncrease = 5f;
   
    void Start()
    {
        StartCoroutine(SpawnRain());
        StartCoroutine(SpawnIncrease());
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            spawnTimer = 0f;
        }
    }

    IEnumerator SpawnRain()
    {
        Vector3 spawnposition = new((Random.Range(-25,25)), 10, (Random.Range(-25,25)));

        Instantiate(rainPrefab, spawnposition, Quaternion.identity);
        yield return new WaitForSeconds(spawnTimer);
        StartCoroutine(SpawnRain());
    }
    IEnumerator SpawnIncrease()
    {
        yield return new WaitForSeconds(rateIncrease);
        if (spawnTimer >= 0.5f)
        {
            spawnTimer -= 0.2f;
        }
        StartCoroutine(SpawnRain());
        StartCoroutine(SpawnIncrease());
    }
}
