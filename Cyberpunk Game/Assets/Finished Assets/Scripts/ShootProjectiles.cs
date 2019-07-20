using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectiles : MonoBehaviour
{
    [SerializeField] private float shootTimeIntervals=3f;
    [SerializeField] private GameObject[] guns;
    [SerializeField] private GameObject projectile;
    [SerializeField] private bool sentryToggle =true;

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
        if (sentryToggle)
        {
            foreach (var gun in guns)
            {
                Instantiate(projectile, gun.transform.position, gun.transform.rotation);
            }

            Debug.Log(gameObject.name + " shot projectiles");
            timer = 0;
        }

    }
    public void TurnOff(float offTime)
    {
        if (sentryToggle)
        {
            sentryToggle = false;
            Debug.Log(gameObject.name + " turned off.");
            StartCoroutine((TurnOn(offTime)));
        }
    }
    private IEnumerator TurnOn(float offTime)
    {
        yield return new WaitForSeconds(offTime);
        Debug.Log(gameObject.name + " turned on.");
        sentryToggle = true;
    }
}
