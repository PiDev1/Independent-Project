using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainScript : MonoBehaviour
{
    //defines the variables like the time it takes to spawn the rain object
    public GameObject gameManager;
    public GameObject rainPrefab;
    public GameObject player;

    Score score;

    public float spawnTimer = 2f;
    public float rateIncrease = 5f;
   
    //Starts the functions to spawn the rain and increase the rate of spawn
    void Start()
    {
        score = gameManager.GetComponent<Score>();
        StartCoroutine(SpawnRain());
        StartCoroutine(SpawnIncrease());
    }

    //secret fun feature that detects whenever the user presses a specific button, setting the timer to zero
    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            spawnTimer = 0f;
        }
    }

    //a function allowing the use of time and waiting that spawns the rain object after the timer amount
    public IEnumerator SpawnRain()
    {
        player = GameObject.FindWithTag("Player");
        Vector3 spawnposition = new((Random.Range(-25,25)), 10, (Random.Range(-25,25)));
        if (player)
        {
            score.AddScore();
        }
        Instantiate(rainPrefab, spawnposition, Quaternion.identity);
        yield return new WaitForSeconds(spawnTimer);
        StartCoroutine(SpawnRain());
    }

    //a function allowing the use of time and waiting that increases the frequency of how much the rain spawns
     public IEnumerator SpawnIncrease()
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
