using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFXLifeTimer : MonoBehaviour
{

    [SerializeField] float timer;
    private void Start()
    {
        Destroy(gameObject, timer);
    }
}
