using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float range = 5;
    public float health = 100;
    public Camera cam;
    // Start is called before the first frame update
    public void TakeDamage(float amount){
        health -= amount;
        if(health <=0f){
            Die();
        }
    }
    void Die(){
        Debug.Log("Ti ymer");
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.E)){
            Najatie();
        }
    }

    void Najatie(){
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)){
            button Button = hit.transform.GetComponent<button>();
            if(Button != null){
                Button.Choose = true;
                Debug.Log("NAJAL");
            }
        }
    }
}
