using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum CollectableType
{
    Health,
    Blaster1,
    Blaster2,
    Rocket,
    Missile
}
public class Collectables : MonoBehaviour
{
    public CollectableType type;
    [SerializeField] private float moveSpeed;
    private Vector3 tempPos;
    [HideInInspector] public float heathValue;
    private float minHealth = 10f, maxHealth = 30f;

    private void OnDisable()
    {
        SoundManager.instance.PlayPickUpSound();
    }
    // Update is called once per frame
    void Update()
    {
        tempPos = transform.position;
        tempPos.y -= moveSpeed * Time.deltaTime;
        transform.position = tempPos;
    }
}
