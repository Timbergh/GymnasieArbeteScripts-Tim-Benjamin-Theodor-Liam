using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceDoor : MonoBehaviour
{

    private DoorTemplates templates;
    private RoomTemplates roomTemplates;
    public int doorDirection;
    // 1 --> needs top-left door
    // 2 --> needs bottom-left door
    // 3 --> needs bottom-right door
    // 4 --> needs top-right door

   void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("FoundDoor")){ {
            print("Door against no door found!");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            templates = GameObject.FindGameObjectWithTag("Doors").GetComponent<DoorTemplates>();
            roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
            Destroy(gameObject);
            if (doorDirection == 1) {
                Instantiate(templates.topLeftDoor, transform.position, templates.topLeftDoor.transform.rotation);
            }
            if (doorDirection == 2) {
                Instantiate(templates.bottomLeftDoor, transform.position, templates.bottomLeftDoor.transform.rotation);
            }
            if (doorDirection == 3) {
                Instantiate(templates.bottomRightDoor, transform.position, templates.bottomRightDoor.transform.rotation);
            }
            if (doorDirection == 4) {
                Instantiate(templates.topRightDoor, transform.position, templates.topRightDoor.transform.rotation);
            }
        }
        }
    }  
}
