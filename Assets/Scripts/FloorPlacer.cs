using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorPlacer : MonoBehaviour
{
    public GameObject doorObj;
    door Door;
    public Floor[] FloorPrefabs;
    public Floor FirstFloor;
    private List<Floor> spawnedFloor = new List<Floor>();
    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        Door = doorObj.GetComponent<door>();
        spawnedFloor.Add(FirstFloor);
    }

    // Update is called once per frame
    void Update()
    {
        if(Door.Choose == 1 && count == 0){
            SpawnFloor();
            Door.Choose = 0;
            count = 1;
        };
    }

    private void SpawnFloor(){
        Floor newFloor = Instantiate(FloorPrefabs[Random.Range(0, FloorPrefabs.Length)]);
        newFloor.transform.position = spawnedFloor[spawnedFloor.Count-1].End.position - newFloor.Begin.localPosition;
        spawnedFloor.Add(newFloor);
    }
}
