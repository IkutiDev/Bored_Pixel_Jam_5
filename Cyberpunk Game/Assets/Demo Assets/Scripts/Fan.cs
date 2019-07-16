using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private bool fanToggle=true;
    [SerializeField] private float offTime=5f;
    [SerializeField] private Transform centerOfFan;
    private float timer;

    private void Awake()
    {
        gameObject.GetComponentInChildren<Rigidbody2D>().centerOfMass= centerOfFan.position;
    }

    public void TurnOff()
    {
        if (fanToggle)
        {
            Debug.Log(gameObject.name+" turned off.");
            fanToggle = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(false); // If Windarea is not first child change this line !!!
            StartCoroutine(nameof(TurnOn));
        }
    }

    private IEnumerator TurnOn()
    {
        yield return new WaitForSeconds(offTime);
        Debug.Log(gameObject.name + " turned on.");
        gameObject.transform.GetChild(0).gameObject.SetActive(true); // If Windarea is not first child change this line !!!
        fanToggle = true;
    }
}
