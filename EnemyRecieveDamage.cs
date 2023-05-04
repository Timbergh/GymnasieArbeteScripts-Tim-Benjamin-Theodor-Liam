using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRecieveDamage : MonoBehaviour
{
    public float health;
    public float maxHealth;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage){
        health -= damage;
        if (health <= 0)
        {
        CheckDeath();
        }
    }

// Om enemy ska ha en healing ability

    // private void CheckOverheal(){
    //     if (health > maxHealth)
    //     {
    //         health = maxHealth;
    //     }
    // }

    private void CheckDeath()
    {
        Destroy(gameObject);
    }
}
