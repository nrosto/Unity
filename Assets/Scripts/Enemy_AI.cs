using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    Player hp;
    //public GameObject PlayerObject;
    private Transform player;
    private bool CanHit;
    public float Damage = 20;
    private int Timer;
    void Awake(){
        
    }
    void Start()
    {
        Timer = 0;
        CanHit = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        hp = player.GetComponent<Player>();
        StartCoroutine(findPath());
        StartCoroutine(playerDetect());
    }

    IEnumerator playerDetect(){
        while(true){
            if(player == null){
                break;
            }
            if(Vector3.Distance(transform.position, player.position) < 5f)
            {
                animator.SetBool("attack", true);
                Timer++;
                CanHit = true;
                if(Timer == 10 && CanHit)
                {
                    hp.TakeDamage(Damage);
                    Timer = 0;
                    CanHit = false;
                } else {
                    
                }
            } else 
            {
                animator.SetBool("attack", false);
                CanHit = false;
                Timer = 0;
            }
            yield return new WaitForSeconds(0.2f);
        }
    }
    IEnumerator findPath(){
        while(true){
            if(player != null){
                navMeshAgent.SetDestination(player.position);
                yield return new WaitForSeconds(0.1f);
            } else break;
        }
    }

    public void damage(){
        StopAllCoroutines();
        navMeshAgent.enabled = false;
        animator.SetTrigger("die");
        gameObject.GetComponent<BoxCollider>().enabled = false;
        Destroy(gameObject, 5.0f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
