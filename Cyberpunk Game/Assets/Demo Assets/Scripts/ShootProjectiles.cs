using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    [SerializeField] private float shootTimeIntervals=3f;
    [SerializeField] private GameObject[] guns;
    [SerializeField] private GameObject projectile;

    private float timer;
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootTimeIntervals)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        foreach (var gun in guns)
        {
            Instantiate(projectile,gun.transform.position,gun.transform.rotation);
        }
        Debug.Log(gameObject.name+" shot projectiles");
        timer = 0;
    }
}
