using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EarnCheckpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.GetComponent<PlatformerDamage>().lastCheckPoint.transform != gameObject.transform)
            {
                Debug.Log(gameObject.name + " earned");

                other.gameObject.GetComponent<PlatformerDamage>().lastCheckPoint = gameObject.transform;
            }
        }
    }
}
