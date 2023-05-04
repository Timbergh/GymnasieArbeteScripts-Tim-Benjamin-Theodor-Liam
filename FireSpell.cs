using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireSpell : MonoBehaviour
{
   public GameObject projectile;
   public string soundName;
   public float minDamage; 
   public float maxDamage;
   public float cooldown;
   public float projectileForce;
   public bool IsAvailable = true;

    IEnumerator StartCooldown()
     {
        IsAvailable = false;
        yield return new WaitForSeconds(cooldown);
        IsAvailable = true;
     }

   void Update(){
       if (IsAvailable == false)
         {
             return; 
         }

        if (Input.GetMouseButton(0)){
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 myPos = transform.position;
            Vector2 direction = (mousePos - myPos).normalized;
            Vector3 offset = new Vector3( direction.x, direction.y, 0 );
            GameObject spell = Instantiate(projectile, transform.position + offset, Quaternion.identity); //Quaternion.identity Basically betyder ingen rotation, bara från var den är ursprunget.
            spell.GetComponent<Rigidbody2D>().velocity = direction * projectileForce;
            spell.GetComponent<Projectile>().damage = Random.Range(minDamage, maxDamage);

            FindObjectOfType<AudioManager>().Play(soundName);

        StartCoroutine(StartCooldown());
        } 
   }
   
}

