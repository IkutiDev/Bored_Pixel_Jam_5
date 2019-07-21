using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField] private GameObject changeHumanStateGameObject;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            changeHumanStateGameObject.BroadcastMessage("ChangeState");
            gameObject.SetActive(false);
        }
    }
}
