using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    [SerializeField] private GameObject connectedGameObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (connectedGameObject != null)
        {
            connectedGameObject.BroadcastMessage("TurnOff");
        }
    }
}
