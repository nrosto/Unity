using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnPoint;

    private int rand;
    private int randPosition;
    public float startTimeSpawns;
    private float timeSpawns;
    // Start is called before the first frame update
    void Start()
    {
        timeSpawns = startTimeSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if(timeSpawns <=0)
        {
            rand = Random.Range(0, enemy.Length);
            randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(enemy[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeSpawns = startTimeSpawns;
        }
        else
        {
            timeSpawns -= Time.deltaTime;
        }
    }
}
