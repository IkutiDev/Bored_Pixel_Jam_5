using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    void Start()
    {
        CinemachineVirtualCamera virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
        GameObject playerPrefabClone=Instantiate(playerPrefab, transform.position, playerPrefab.transform.rotation);
        virtualCamera.Follow = playerPrefabClone.transform;
    }
}
