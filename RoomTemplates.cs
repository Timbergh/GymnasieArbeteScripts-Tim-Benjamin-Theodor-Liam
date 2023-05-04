using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] bottomRightRooms;
    public GameObject[] bottomLeftRooms;
    public GameObject[] topRightRooms;
    public GameObject[] topLeftRooms;

    public GameObject closedRoom;
    [Range(5, 50)]
    public int maxRooms;
    [Range(5, 50)]
    public int minRooms;
    

    public List<GameObject> rooms;
}
