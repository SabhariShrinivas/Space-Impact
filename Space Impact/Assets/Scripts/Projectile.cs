using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    public float minDamage = 5f;
    public float maxDamage = 6f;
    private float projectileDamage;
    [SerializeField] private GameObject boomSound;
    [SerializeField] AudioClip spawnSound;
    [SerializeField] AudioClip destroySound;

    private void OnEnable()
    {
        if (spawnSound)
            AudioSource.PlayClipAtPoint(spawnSound, new Vector3(0f, 0f, 0f));
    }
    private void Start()
    {
    projectileDamage = (int)Random.Range(minDamage, maxDamage);
    }  
    private void Update()
    {
        transform.Translate(0f, speed * Time.deltaTime, 0f); 
    }
}
