using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    [ Header("Set in Inspector")  ]
    public GameObject goodPrefab, badPrefab;

    public int pauseTime = 2; //may need to customize for your game
    public int numToSpawn = 10; //customize as needed
    public float chanceToSpawnBad = 0.10f; //modify as needed
    public bool activeSpawning = false;
    public float xRange = 8.0f; //customize as needed
    public float yRangeTop = -2.0f; //customize as needed
    public float yRangeBottom = -3.5f; //customize as needed

    // Start is called before the first frame update
    void Start()
    {
        //activeSpawning = true; //remove this code later
        //StartSpawning(); //remove this code later, move to MiniGameManager
    }

    public void StartSpawning()
    {
        Debug.Log("Start Spawning called");
        for( int i= 0; i< numToSpawn; i++)
        {
            Invoke("SpawnPrefab", pauseTime * i * 2);
        }
    }

    public void SpawnPrefab()
    {
        if (activeSpawning)
        {
            //Where to spawn based on transform of Spawner gameObject

            Vector3 position = transform.localPosition;
            position.x = Random.Range(-xRange, xRange);
            position.y = Random.Range(yRangeBottom, yRangeTop);

            float rand = Random.value;
            GameObject prefab; //temp variable 
            if( rand < chanceToSpawnBad)
            { //spawn bad prefab
                prefab = Instantiate(badPrefab, position, transform.rotation);
            }
            else  //instantiate good one
            {
                prefab = Instantiate(goodPrefab, position, transform.rotation);
            }
            prefab.transform.SetParent(this.transform); //all spawned objects will be children of the Spawner gameObject
        }
    }//end SpawnPrefab

    public void DestroyAllPickups()
    {
        PickUpPrefab[] items = FindObjectsOfType<PickUpPrefab>();
        foreach( PickUpPrefab item in items       )
        {
            Destroy(item.gameObject);
        }
    }

}// end class
