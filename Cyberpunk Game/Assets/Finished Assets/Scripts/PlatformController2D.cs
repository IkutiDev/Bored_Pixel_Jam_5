using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController2D : MonoBehaviour
{
    [SerializeField] private float speed=5f;

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
        transform.position=new Vector2(transform.position.x,Mathf.Clamp(transform.position.y,-60f,26.5f));
        if (transform.position.y > 26.5f)
        {
            transform.position = new Vector2(transform.position.x,26.45f);
        }
    }
}
