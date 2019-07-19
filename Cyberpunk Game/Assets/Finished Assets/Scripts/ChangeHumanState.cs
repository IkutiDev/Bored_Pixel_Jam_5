using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHumanState : MonoBehaviour
{
    [SerializeField] private ControlHuman.HumanState newState;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Human"))
        {
            if (collision.GetComponent<ControlHuman>().currentState != ControlHuman.HumanState.Jumping)
            {
                collision.GetComponent<ControlHuman>().currentState = newState;
            }
        }
    }
}
