using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    private DoorTemplates templates;
    private RoomTemplates roomTemplates;
    private EnemySpawner enemies;
    public int doorDirection;
    // 1 --> needs top-left door
    // 2 --> needs bottom-left door
    // 3 --> needs bottom-right door
    // 4 --> needs top-right door
    void Start(){
        enemies = GameObject.FindGameObjectWithTag("Room").GetComponent<EnemySpawner>();
    }

    IEnumerator OpenDoors()
     {
        yield return new WaitForSeconds(1f);
        templates = GameObject.FindGameObjectWithTag("Doors").GetComponent<DoorTemplates>();
        roomTemplates = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplates>();
        Destroy(gameObject);
        if (doorDirection == 1) {
            Instantiate(templates.topLeftDoorOpen, transform.position, templates.topLeftDoorOpen.transform.rotation);
        }
        if (doorDirection == 2) {
            Instantiate(templates.bottomLeftDoorOpen, transform.position, templates.bottomLeftDoorOpen.transform.rotation);
        }
        if (doorDirection == 3) {
            Instantiate(templates.bottomRightDoorOpen, transform.position, templates.bottomRightDoorOpen.transform.rotation);
        }
        if (doorDirection == 4) {
            Instantiate(templates.topRightDoorOpen, transform.position, templates.topRightDoorOpen.transform.rotation);
        }
     }

    void Update(){
        if (enemies.enemiesRemaining == 0){
            StartCoroutine(OpenDoors());
        }
    }
}
