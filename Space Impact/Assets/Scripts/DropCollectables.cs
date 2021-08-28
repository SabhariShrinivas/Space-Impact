using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCollectables : MonoBehaviour
{
    [SerializeField] private GameObject[] collectables;


    public void CheckToSpawnCollectables()
    {
        if(Random.Range(0, 4) > 2)
        {
            Instantiate(collectables[Random.Range(0, collectables.Length)], transform.position, Quaternion.identity);
        }
    }
}
