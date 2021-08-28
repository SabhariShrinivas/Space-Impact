using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgrades : MonoBehaviour
{
    [SerializeField] private WeaponUpgrade weaponUpgrade;
    private Collectables collectables;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TagManager.COLLECTABLE_TAG))
        {
            collectables = collision.GetComponent<Collectables>();
            if(collectables.type == CollectableType.Blaster1)
            {
                weaponUpgrade.ActivateWeapons(0);
            }
            if (collectables.type == CollectableType.Blaster2)
            {
                weaponUpgrade.ActivateWeapons(1);
            }
            if (collectables.type == CollectableType.Missile)
            {
                weaponUpgrade.ActivateWeapons(2);
            }
            if (collectables.type == CollectableType.Rocket)
            {
                weaponUpgrade.ActivateWeapons(3);
            }
            DestroyCollectable(collectables);

        }
    }
    void DestroyCollectable(Collectables col)
    {
        if(col.type != CollectableType.Health)
        {
            Destroy(col.gameObject);
        }
    }
}
