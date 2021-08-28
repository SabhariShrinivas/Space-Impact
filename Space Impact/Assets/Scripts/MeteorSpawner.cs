using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] Meteors;
    [SerializeField] float minX, maxX;
    private float minSpawnInterval = 4f, maxSpawnInterval = 10f;
    private int randSpawnNum;
    private Vector3 randSpawnPosition;

    private void Start()
    {
        Invoke("SpawnMeteors", Random.Range(minSpawnInterval, maxSpawnInterval));
    }
   
    void SpawnMeteors()
    {
        randSpawnNum = Random.Range(0, Meteors.Length);

        for(int i = 0; i < randSpawnNum; i++)
        {
            randSpawnPosition = new Vector3(Random.Range(minX, maxX), transform.position.y, 0);
            Instantiate(Meteors[Random.Range(0, Meteors.Length)], randSpawnPosition, Quaternion.identity);
        }
        Invoke("SpawnMeteors", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

}
