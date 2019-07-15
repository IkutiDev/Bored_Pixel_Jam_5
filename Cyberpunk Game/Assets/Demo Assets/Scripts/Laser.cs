using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private bool laserToggle=true;
    [SerializeField] private float offTime=4f;
    public void TurnOff()
    {
        if (laserToggle)
        {
            laserToggle = false;
            Debug.Log(gameObject.name + " turned off.");
            gameObject.GetComponent<SpriteRenderer>().enabled=false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(nameof(TurnOn));
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ouch, "+gameObject.name+" hurt me.");
            //other.GetComponent<>() Loosing HP or dying over here
        }
    }

    private IEnumerator TurnOn()
    {
        yield return new WaitForSeconds(offTime);
        Debug.Log(gameObject.name + " turned on.");
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        laserToggle = true;
    }
}
