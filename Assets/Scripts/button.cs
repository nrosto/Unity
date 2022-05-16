using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Choose;
    
    void Start()
    {
        Choose = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider other) {
        Debug.Log("Tikai");
        if(Input.GetKeyDown(KeyCode.E)){
            Debug.Log("Najal");
        }
        if(other.tag == "Player" && Input.GetKeyDown(KeyCode.E)){
            Choose = true;
        }    
    }
    
    public void Destroy(){
        Destroy(gameObject);
    }
}
