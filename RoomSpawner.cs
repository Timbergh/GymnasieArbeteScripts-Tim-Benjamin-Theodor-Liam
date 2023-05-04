using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 --> needs top-left door
    // 2 --> needs bottom-left door
    // 3 --> needs bottom-right door
    // 4 --> needs top-right door

    private RoomTemplates templates;
    private int rand;
    public bool spawned = false;

    public float waitTime = 3f;

    void Start(){
        Destroy(gameObject, waitTime);
        templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Invoke("Spawn", 0.3f);
    }

    void Spawn(){
        if (spawned == false){
            if (openingDirection == 1){
                // Spawn room with top-left door
                rand = Random.Range(0, templates.topLeftRooms.Length);
                if(rand == 0 && templates.rooms.Count != templates.maxRooms && templates.rooms.Count <= templates.minRooms) {
                    rand = Random.Range(1, templates.topLeftRooms.Length);
                }
                if(templates.rooms.Count >= templates.maxRooms - 5) {
                Instantiate(templates.topLeftRooms[0], transform.position, templates.topLeftRooms[0].transform.rotation);
                } else {
                Instantiate(templates.topLeftRooms[rand], transform.position, templates.topLeftRooms[rand].transform.rotation);
                }
            } else if (openingDirection == 2){
                // Spawn room with bottom-left door
                rand = Random.Range(0, templates.bottomLeftRooms.Length);
                if(rand == 0 && templates.rooms.Count != templates.maxRooms && templates.rooms.Count <= templates.minRooms) {
                rand = Random.Range(1, templates.bottomLeftRooms.Length);
                }
                if(templates.rooms.Count >= templates.maxRooms - 5) {
                Instantiate(templates.bottomLeftRooms[0], transform.position, templates.bottomLeftRooms[0].transform.rotation);
                }else {
                Instantiate(templates.bottomLeftRooms[rand], transform.position, templates.bottomLeftRooms[rand].transform.rotation);
                }
            } else if (openingDirection == 3){
                // Spawn room with bottom-right door
                rand = Random.Range(0, templates.bottomRightRooms.Length);
                if(rand == 0 && templates.rooms.Count != templates.maxRooms && templates.rooms.Count <= templates.minRooms) {
                rand = Random.Range(1, templates.bottomRightRooms.Length);
                }
                if(templates.rooms.Count >= templates.maxRooms - 5) {
                Instantiate(templates.bottomRightRooms[0], transform.position, templates.bottomRightRooms[0].transform.rotation);
                } else {
                Instantiate(templates.bottomRightRooms[rand], transform.position, templates.bottomRightRooms[rand].transform.rotation);
                }
            } else if (openingDirection == 4){
                // Spawn room with top-right door
                rand = Random.Range(0, templates.topRightRooms.Length);
                if(rand == 0 && templates.rooms.Count != templates.maxRooms && templates.rooms.Count <= templates.minRooms) {
                rand = Random.Range(1, templates.topRightRooms.Length);
                }
                if(templates.rooms.Count >= templates.maxRooms - 5) {
                Instantiate(templates.topRightRooms[0], transform.position, templates.topRightRooms[0].transform.rotation);
                } else {
                Instantiate(templates.topRightRooms[rand], transform.position, templates.topRightRooms[rand].transform.rotation);
                }
            }
        }
        spawned = true;
    } 


    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("SpawnPoint")) {
            templates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false) {
                Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
                Destroy(gameObject);
                templates.maxRooms -= 1;
            }
            spawned = true;
        }
    }
}



