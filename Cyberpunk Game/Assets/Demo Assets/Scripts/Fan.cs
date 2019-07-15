using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private bool fanToggle;
    public void TurnOff()
    {
        fanToggle = !fanToggle;
    }
}
