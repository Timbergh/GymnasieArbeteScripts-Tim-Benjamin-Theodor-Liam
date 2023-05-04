using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour{

public Transform player;
public float smoothing = 0.125f;
public Vector3 offset;


void LateUpdate(){
    if(player != null){ 
        Vector3 newPosition = Vector3.Lerp(transform.position, player.transform.position + offset, smoothing);
        transform.position = newPosition;
    }
  
}
}
   
