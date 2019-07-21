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
            if (CVC.Follow == humanTransform)
            {
                CVC.Follow = platformTransform;
                CVC.m_Lens.OrthographicSize = 8f;
            }
            else
            {
                CVC.Follow = humanTransform;
                CVC.m_Lens.OrthographicSize = 12f;
            }
        }
    }
}
