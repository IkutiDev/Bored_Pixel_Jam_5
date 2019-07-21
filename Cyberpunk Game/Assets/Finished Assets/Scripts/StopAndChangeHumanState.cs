using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAndChangeHumanState : MonoBehaviour
{
    [SerializeField] private ControlHuman.HumanState newState;
    [SerializeField] private float timeToWait;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject human=collision.gameObject;
        if (collision.CompareTag("Human"))
        {
            human.GetComponent<ControlHuman>().currentState = ControlHuman.HumanState.Stop;
        }
    }

    public void ChangeState()
    {
        if (GameObject.FindGameObjectWithTag("Human").GetComponent<ControlHuman>().currentState ==
            ControlHuman.HumanState.Stop)
        {
            GameObject.FindGameObjectWithTag("Human").GetComponent<ControlHuman>().currentState = newState;
        }
    }
}
