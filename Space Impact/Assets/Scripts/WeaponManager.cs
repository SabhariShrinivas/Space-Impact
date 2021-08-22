using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private GameObject[] projectile;
    [SerializeField] private Transform[] projectileSpawnPoints; 
    [SerializeField] private float shootTimerThreshold = 0.2f; //to control fire rate
    private float shootTimer;
    private bool canShoot;

    private void Update()
    {
        if(Time.time > shootTimer) { canShoot = true; }
        HandlePlayerShooting();
    }
    void HandlePlayerShooting()
    {
        if (!canShoot) { return; }
        if (Input.GetKeyDown(KeyCode.J)) //blaster 1
        {
            Instantiate(projectile[0], projectileSpawnPoints[0].position, Quaternion.identity);
            Instantiate(projectile[0], projectileSpawnPoints[1].position, Quaternion.identity);
            ResetShootingTimer();

        }
        if (Input.GetKeyDown(KeyCode.K)) //blaster 2
        {
            Instantiate(projectile[1], projectileSpawnPoints[0].position, Quaternion.identity);
            Instantiate(projectile[1], projectileSpawnPoints[1].position, Quaternion.identity);
            ResetShootingTimer();

        }
        if (Input.GetKeyDown(KeyCode.L)) //laser
        {
            Instantiate(projectile[2], projectileSpawnPoints[0].position, Quaternion.identity);
            Instantiate(projectile[2], projectileSpawnPoints[1].position, Quaternion.identity);
            ResetShootingTimer();

        }
        if (Input.GetKeyDown(KeyCode.O)) //rocket
        {
            Instantiate(projectile[3], projectileSpawnPoints[2].position, Quaternion.identity);
            ResetShootingTimer();

        }
        if (Input.GetKeyDown(KeyCode.P)) //missile
        {
            Instantiate(projectile[4], projectileSpawnPoints[2].position, Quaternion.identity);
            ResetShootingTimer();

        }
    }
    void ResetShootingTimer()
    {
        canShoot = false;
        shootTimer = Time.time + shootTimerThreshold;
    }
}
