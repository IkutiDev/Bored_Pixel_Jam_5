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
            if (human.GetComponent<ControlHuman>().currentState != ControlHuman.HumanState.Jumping)
            {
                StartCoroutine(ChangeState(timeToWait, human));
            }
        }
    }

    private IEnumerator ChangeState(float time,GameObject human)
    {
        human.GetComponent<ControlHuman>().currentState = ControlHuman.HumanState.Stop;
        yield return new WaitForSeconds(time);
        human.GetComponent<ControlHuman>().currentState = newState;

    }
}
