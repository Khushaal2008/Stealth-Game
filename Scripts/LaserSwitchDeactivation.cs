using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSwitchDeactivation : MonoBehaviour
{
    public GameObject laser;
    public Material unlockedMat;

    private GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject == player)
        {
            if(Input.GetButton("Switch"))
            {
                LaserDeactivation();
            }
        }
    }

    void LaserDeactivation()
    {
        laser.SetActive(false);

        Renderer screen = transform.Find("prop_switchUnity_screen_001").GetComponent<Renderer>();
        screen.material = unlockedMat;
        GetComponent<AudioSource>().Play();
    }
}
