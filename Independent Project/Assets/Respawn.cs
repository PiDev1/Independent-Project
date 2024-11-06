using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public GameObject playerPrefab;
    public GameObject gameManager;
    GameObject[] rain;

    Score score;
    RainScript rainScript;
    void Start()
    {
        score = gameManager.GetComponent<Score>();
        rainScript = gameManager.GetComponent<RainScript>();
    }
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rain = GameObject.FindGameObjectsWithTag("Rain");

        RespawnPlayer();
    }

    void RespawnPlayer()
    {
        Vector3 spawn = new(0, 3, 0);

        if (Input.GetKeyDown(KeyCode.R))
        {
            Destroy(player);
        }

        if (!player)
        {
            Debug.Log("GAME OVER");

            rainScript.StopAllCoroutines();
            rainScript.StartCoroutine(rainScript.SpawnRain());
            rainScript.StartCoroutine(rainScript.SpawnIncrease());

            score.scoreValue = 0;
            score.scoreText.text = score.scoreValue.ToString();

            foreach (GameObject Rain in rain)
            {
                Destroy(Rain);
            }

            rainScript.spawnTimer = 2f;
            rainScript.rateIncrease = 5f;
            Instantiate(playerPrefab, spawn, Quaternion.identity);
            Debug.Log("Player Spawned");
        }
    }
}
