using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerDamage : MonoBehaviour
{
    public Transform lastCheckPoint;

    public void Damage()
    {
        transform.position = lastCheckPoint.position;
    }
}
