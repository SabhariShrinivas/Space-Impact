using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{

    [SerializeField] private WeaponManagerPool[] weapons;

    public void ActivateWeapons(int WeaponIndex)
    {
        weapons[WeaponIndex].enabled = true;
    }
}
