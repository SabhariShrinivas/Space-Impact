using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag(TagManager.PROJECTILE_TAG))
        {
            collision.gameObject.SetActive(false);
        }
    }
}
