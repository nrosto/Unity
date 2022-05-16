using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Enemy_AI enemyAI;
    public float health = 50f;

    void Awake(){
        enemyAI = GetComponent<Enemy_AI>();
    }
    public void TakeDamage(float amount){
        health -= amount;
        if (health <= 0f){
            enemyAI.damage();
        }
    }
}
