using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoors : MonoBehaviour
{
    private GameObject lowerDoorPart;
    private GameObject upperDoorPart;
    private float startPositionLower;
    private float startPositionUpper;
    [SerializeField] private float doorSpeed=2f;
    private float previousDoorSpeed;
    public bool reverse = false;
    [SerializeField] private bool doorToggle = true;

    private void Awake()
    {
        upperDoorPart = gameObject.transform.GetChild(0).gameObject;
        lowerDoorPart = gameObject.transform.GetChild(1).gameObject;
        startPositionLower = lowerDoorPart.transform.position.y;
        Debug.Log(startPositionLower);
        startPositionUpper = upperDoorPart.transform.position.y;
        Debug.Log(startPositionUpper);
        doorSpeed = Mathf.Clamp(doorSpeed, 0f, 20f);//Wiekszy/mniejszy speed moze popsuc drzwi
    }

    private void Update()
    {
        if (!reverse)
        {
            upperDoorPart.transform.Translate(Time.deltaTime * doorSpeed * Vector2.down);
            lowerDoorPart.transform.Translate(Time.deltaTime * doorSpeed * Vector2.up);
        }
        else
        {
            upperDoorPart.transform.Translate(Time.deltaTime * doorSpeed * -Vector2.down);
            lowerDoorPart.transform.Translate(Time.deltaTime * doorSpeed * -Vector2.up);
            if (lowerDoorPart.transform.position.y<=startPositionLower && upperDoorPart.transform.position.y >=startPositionUpper)
            {
                Debug.Log("Back");
                reverse = false;
                upperDoorPart.GetComponentInChildren<OnHitGoBack>().enabled = true;
                lowerDoorPart.GetComponentInChildren<OnHitGoBack>().enabled = true;
            }

        }
    }
    public void TurnOff(float offTime)
    {
        if (doorToggle)
        {
            doorToggle = false;
            Debug.Log(gameObject.name + " turned off.");
            previousDoorSpeed = doorSpeed;
            doorSpeed = 0f;
            StartCoroutine((TurnOn(offTime)));
        }
    }
    private IEnumerator TurnOn(float offTime)
    {
        yield return new WaitForSeconds(offTime);
        Debug.Log(gameObject.name + " turned on.");
        doorSpeed = previousDoorSpeed;
        doorToggle = true;
    }
}
