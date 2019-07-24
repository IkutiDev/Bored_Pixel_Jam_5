using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private bool fanToggle=true;
    //[SerializeField] private float offTime=5f;
    private float timer;

    public void TurnOff(PushButton.ButtonStruct buttonStruct)
    {
        if (fanToggle)
        {
            Debug.Log(gameObject.name+" turned off.");
            if (!buttonStruct.CanPressPressedButton)
            {
                fanToggle = false;
            }
            gameObject.transform.GetChild(0).gameObject.SetActive(false); // If Windarea is not first child change this line !!!
            if (buttonStruct.CanPressPressedButton)
            {
                StopAllCoroutines();
            }
            StartCoroutine(TurnOn(buttonStruct.OffTime));
        }
    }

    private IEnumerator TurnOn(float offTime)
    {
        yield return new WaitForSeconds(offTime);
        Debug.Log(gameObject.name + " turned on.");
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // If Windarea is not first child change this line !!!
        fanToggle = true;
    }
}
