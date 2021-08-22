using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLifeTimer : MonoBehaviour
{
    [SerializeField] int timer = 3;

    private void OnEnable()
    {
        Invoke("DeactivateProjectile", timer);
    }
    private void OnDisable()
    {
        CancelInvoke("DeactivateProjectile");
    }
    void DeactivateProjectile()
    {
        if (gameObject.activeInHierarchy)
        {
            gameObject.SetActive(false);
        }
    }
}
