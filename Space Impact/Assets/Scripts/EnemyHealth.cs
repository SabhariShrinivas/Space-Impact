using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private GameObject healthBar;
    private Vector3 healthBarScale;
    [SerializeField] private float health = 100f;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private GameObject hitEffect;
    private DropCollectables dropCollectables;

    private void Start()
    {
        dropCollectables = GetComponent<DropCollectables>();
    }
    public void TakeDamage(float damageAmount, float damageResistance)
    {
        damageAmount -= damageResistance;
        health -= damageAmount;

        if (health <= 0)
        {
            health = 0;
            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            SoundManager.instance.PlayDestroySound();
            if (gameObject.CompareTag(TagManager.ENEMY_TAG)) 
            { 
                GameplayUIController.instance.SetInfo(2);
                EnemySpawner.instance.CheckToSpawnNewWave(gameObject);
            }
            else { GameplayUIController.instance.SetInfo(3); }
            Destroy(gameObject);
            dropCollectables.CheckToSpawnCollectables();
        }
        else
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
            SoundManager.instance.PlayDamageSound();
        }

        SetHealthBar();
    }

    private void SetHealthBar()
    {
        if (!healthBar)
        {
            return;
        }
        healthBarScale = healthBar.transform.localScale;
        healthBarScale.x = health / 100;
        healthBar.transform.localScale = healthBarScale;
    }
}
