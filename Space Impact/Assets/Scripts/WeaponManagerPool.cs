using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagerPool : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    List<GameObject> projectilePool = new List<GameObject>();
       private GameObject projectileHolder;
    [SerializeField] private KeyCode keyToPressToShoot;
    [SerializeField] private Transform ProjectileSpawnPoint;
    [SerializeField] private float shootWaitTime;
    [SerializeField] private bool isEnemy;
    private float shootTimer;
    private bool canShoot;
    private bool projectileSpawned;

    private void Awake()
    {
        if (isEnemy)
        {
            projectileHolder = GameObject.FindWithTag(TagManager.ENEMY_PROJECTILE_HOLDER_TAG);
            ResetShootTimer();
        }
        else
        {
            projectileHolder = GameObject.FindWithTag(TagManager.PLAYER_PROJECTILE_HOLDER_TAG);
        }
    }
    private void Update()
    {
        if (Time.time > shootTimer) { canShoot = true; }
        HandlePlayerShooting();
        HandleEnemyShooting();

    }
    public void HandlePlayerShooting()
    {
        if(!canShoot || isEnemy) { return; }
        if (Input.GetKeyDown(keyToPressToShoot))
        {
            GetObjectFromPoolOrSpawnANewOne();
            ResetShootTimer();
        }
    }
    void GetObjectFromPoolOrSpawnANewOne()
    {
        for (int i = 0; i < projectilePool.Count; i++)
        {
            if (!projectilePool[i].activeInHierarchy)
            {
                projectilePool[i].transform.position = ProjectileSpawnPoint.position;
                projectilePool[i].SetActive(true);
                projectileSpawned = true;
                break;
            }
            else
            {
                projectileSpawned = false;
            }
        }
            if (!projectileSpawned)
            {
                GameObject newProjectile = Instantiate(projectile, ProjectileSpawnPoint.position, Quaternion.identity);
                projectilePool.Add(newProjectile);
                newProjectile.transform.SetParent(projectileHolder.transform);
                projectileSpawned = true;
            }       
    }
    void ResetShootTimer()
    {
        canShoot = false;
        if (isEnemy) 
        {
            shootTimer = Time.time + Random.Range(shootWaitTime, 1f);
        }
        else
        {
            shootTimer = Time.time + shootWaitTime;
        }
    }
    public void HandleEnemyShooting()
    {
        if(!isEnemy || !canShoot) { return; }
        ResetShootTimer();
        GetObjectFromPoolOrSpawnANewOne();
    }
}
