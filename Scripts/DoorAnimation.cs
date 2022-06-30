using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimation : MonoBehaviour
{
    public bool requireKey;
    public AudioClip doorSwishClip;
    public AudioClip accessDeniedClip;

    private Animator anim;
    private HashIds hash;
    private GameObject player;
    private PlayerInventory playerInventory;
    private int count;

    void Awake()
    {
        anim = GetComponent<Animator>();
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIds>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerInventory = player.GetComponent<PlayerInventory>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            if(requireKey)
            {
                if(playerInventory.hasKey)
                {
                    count++;
                }
                else
                {
                    GetComponent<AudioSource>().clip =accessDeniedClip;
                    GetComponent<AudioSource>().Play();
                }
            }
            else
            {
                count++;
            }
        } 
        else if(other.gameObject.tag == "Enemy")
        {
            if(other is CapsuleCollider)
            {
                count++;
            }
        }  
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject == player || (other.gameObject.tag == "Enemy" && other is CapsuleCollider))
        {
            count = Mathf.Max(0, count-1);
        }
    }

    void Update()
    {
        anim.SetBool(hash.openBool, count > 0);

        if(anim.IsInTransition(0) && !GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = doorSwishClip;
            GetComponent<AudioSource>().Play();
        }
    }
}
