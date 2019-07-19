using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    private CinemachineVirtualCamera CVC;
    private void Awake()
    {
        CVC = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (CVC.Priority == 0)
            {
                CVC.Priority = 2;
            }
            else
            {
                CVC.Priority = 0;
            }
        }
    }
}
