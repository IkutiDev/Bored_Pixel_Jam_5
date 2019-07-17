using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHitGoBack : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Hit "+other.name);
        if (other.gameObject.CompareTag("CrushingDoor"))
        {
            gameObject.transform.parent.GetComponentInParent<MoveDoors>().reverse = true;
        }

        gameObject.GetComponent<OnHitGoBack>().enabled = false;
    }
}
