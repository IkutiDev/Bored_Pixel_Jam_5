using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private Transform platformTransform;
    [SerializeField] private Transform humanTransform;
    private CinemachineVirtualCamera CVC;
    private void Awake()
    {
        CVC = GetComponent<CinemachineVirtualCamera>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CVC.Follow = CVC.Follow == humanTransform ? platformTransform : humanTransform;
        }
    }
}
