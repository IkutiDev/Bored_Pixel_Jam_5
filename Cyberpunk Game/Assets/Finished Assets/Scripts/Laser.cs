using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private bool laserToggle=true;
    public void TurnOff(float offTime)
    {
        if (laserToggle)
        {
            laserToggle = false;
            Debug.Log(gameObject.name + " turned off.");
            gameObject.GetComponent<SpriteRenderer>().enabled=false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine((TurnOn(offTime)));
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ouch, "+gameObject.name+" hurt me.");
            other.GetComponent<PlatformerDamage>().Damage();
        }
    }

    private IEnumerator TurnOn(float offTime)
    {
        yield return new WaitForSeconds(offTime);
        Debug.Log(gameObject.name + " turned on.");
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        laserToggle = true;
    }
}
