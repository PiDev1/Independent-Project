using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnRain : MonoBehaviour
{
    //defines the variable for what the player is
    public GameObject player;

    void Start()
    {
        //destroys the rain object after 10 seconds
        GameObject.Destroy(this.gameObject, 10);

        //finds and defines the player object by finding the asset in the scene
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    //when the rain object collides with the player, the player object will be destroyed and removed
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameObject.Destroy(player);
        }
    }
}
