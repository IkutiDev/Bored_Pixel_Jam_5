using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private bool fanToggle=true;
    [SerializeField] private float offTime=5f;
    public void TurnOff()
    {
        if (fanToggle)
        {
            Debug.Log(gameObject.name+" turned off.");
            fanToggle = false;
            StartCoroutine(nameof(TurnOn));
        }
    }

    private IEnumerator TurnOn()
    {
        yield return new WaitForSeconds(offTime);
        Debug.Log(gameObject.name + " turned on.");
        fanToggle = true;
    }
}
