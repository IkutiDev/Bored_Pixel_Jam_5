using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerDamage : MonoBehaviour
{
    public Transform lastCheckPoint;
    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            Damage();
        }
    }

    public void Damage()
    {
        transform.position = lastCheckPoint.position;
    }
}
