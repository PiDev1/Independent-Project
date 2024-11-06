using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    void Start()
    {
        GameObject.Destroy(this.gameObject, 4);
    }
}
