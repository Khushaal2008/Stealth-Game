using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPlayerDetection : MonoBehaviour
{
    private GameObject player;
    private LastPlayerSighting lastPlayerSighting;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        lastPlayerSighting = GameObject.FindGameObjectWithTag("GameController").GetComponent<LastPlayerSighting>();
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
            lastPlayerSighting.position = other.transform.position;
    }
}
