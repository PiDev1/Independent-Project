using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnRain : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        GameObject.Destroy(this.gameObject, 10);
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(player);
        }
    }
}
