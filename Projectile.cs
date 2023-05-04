using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Projectile : MonoBehaviour
{
   public float damage;
   public string soundName;
   public float timeBeforeDestroy = 1f;
   public GameObject hitEffect;

   void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.name != "Player"){
        if(collision.GetComponent<EnemyRecieveDamage>() != null)
        {
            collision.GetComponent<EnemyRecieveDamage>().TakeDamage(damage);
        } 
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        CameraShake.Instance.ShakeCamera(5f, 0.3f);
        FindObjectOfType<AudioManager>().Play(soundName);
        Destroy(effect,3f);
        
        Destroy(gameObject);
    }else{
        Destroy(gameObject, timeBeforeDestroy);
    }
    }

   }
    
