using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToNextRoom : MonoBehaviour
{   
    private Transform Player;
    public Transform TeleportLocation;

    void Start(){
        Player = GameObject.Find("Player").transform;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player"))
        {
            Player.position = TeleportLocation.position;
        }
    }
}
