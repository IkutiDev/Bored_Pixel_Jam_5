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
            collision.GetComponent<ControlHuman>().currentState = newState;
        }
    }
    
}
