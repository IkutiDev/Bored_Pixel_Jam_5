using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileFly : MonoBehaviour
{
    [SerializeField] private float projectileSpeed=5f;

    private void Update()
    {
        transform.Translate(Time.deltaTime * projectileSpeed * Vector2.up);
    }
}
