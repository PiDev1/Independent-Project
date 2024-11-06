using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DespawnRain : MonoBehaviour
{
    //defines the variable for what the player is
    public GameObject player;
    public ParticleSystem dissolve;

    void Start()
    {
        StartCoroutine(DestroyObject());
        //finds and defines the player object by finding the asset in the scene
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    public IEnumerator DestroyObject()
    {
        //destroys the rain object after 10 seconds

        yield return new WaitForSeconds(10);
        GameObject.Destroy(this.gameObject);
        Instantiate(dissolve, transform.position, Quaternion.identity);
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
