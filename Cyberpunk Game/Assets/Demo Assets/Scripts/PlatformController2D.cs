using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController2D : MonoBehaviour
{
    [SerializeField] private float speed=3f;

    private Rigidbody2D _rigidbody2D;
    private Vector2 movementVector2 = Vector2.zero;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        movementVector2 = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

    }

    private void FixedUpdate()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + speed * Time.fixedDeltaTime * movementVector2);
    }
}
