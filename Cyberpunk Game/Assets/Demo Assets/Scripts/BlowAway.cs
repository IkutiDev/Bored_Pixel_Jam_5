using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlowAway : MonoBehaviour
{
    enum Direction
    {
        Up,
        Down,
        Right,
        Left,
    }

    [SerializeField] private Direction direction = Direction.Left;
    [SerializeField] private float speedOfAirForce=15000f;
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Object entetered fan air area");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        switch (direction)
        {
            case Direction.Right:
                other.attachedRigidbody.AddForce(speedOfAirForce * Time.deltaTime * -Vector2.left);
                break;
            case Direction.Left:
                other.attachedRigidbody.AddForce(speedOfAirForce * Time.deltaTime * -Vector2.right);
                break;
            case Direction.Down:
                other.attachedRigidbody.AddForce(speedOfAirForce * Time.deltaTime * -Vector2.up);
                break;
            case Direction.Up:
                other.attachedRigidbody.AddForce(speedOfAirForce * Time.deltaTime * -Vector2.down);
                break;
            default:
                other.attachedRigidbody.AddForce(speedOfAirForce * Time.deltaTime * -Vector2.right);
                break;
        }
        
        //Vector2 position = transform.position;
        //Vector2 targetPosition = other.transform.position;
        //Vector2 direction = targetPosition - position;
        //direction.Normalize();
        //targetPosition += speedOfAirForce * Time.deltaTime * direction;
        //other.transform.position = targetPosition;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Left the fan air area");
    }
}
