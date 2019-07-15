using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private bool laserToggle;
    public void TurnOff()
    {
        laserToggle = !laserToggle;
    }
}
