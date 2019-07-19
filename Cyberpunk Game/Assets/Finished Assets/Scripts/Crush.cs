using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour
{
    public bool playerInCrushingArea;
    [SerializeField] private GameObject otherCrushingArea;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player entered crushing area");
            playerInCrushingArea = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && otherCrushingArea.GetComponent<Crush>().playerInCrushingArea)
        {
            Debug.Log("Player crushed");
            other.gameObject.GetComponent<PlatformerDamage>().Damage();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player left crushing area");
            playerInCrushingArea = false;
        }
    }
}
