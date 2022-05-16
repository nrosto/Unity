using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
    public GameObject Button1;
    public GameObject Button2;
    button button1;
    button button2;
    public int Choose;
    private bool open2;
    private bool open1;
    private Vector3 end;
    private Vector3 start;
    
    // Start is called before the first frame update
    void Start()
    {
        Choose = 0;
        start = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        end = new Vector3(transform.position.x, transform.position.y + 10, transform.position.z);
        button1 = Button1.GetComponent<button>();
        button2 = Button2.GetComponent<button>();
    }

    // Update is called once per frame
    void Update()
    {
        open1 = button1.Choose;
        open2 = button2.Choose;
        if(open1 == true && open2 == false){
            transform.position = Vector3.Lerp(transform.position, end, Time.deltaTime);
            Button2.GetComponent<MeshRenderer>().enabled = false;
            Choose = 1;
            if(transform.position == end){
                button1.Choose = false;
                Choose = 0;
            }
            
        } else if (open1 == false && open2 == true){
            transform.position = Vector3.Lerp(transform.position, end, Time.deltaTime);
            Button1.GetComponent<MeshRenderer>().enabled = false;
            
        }
    }
}