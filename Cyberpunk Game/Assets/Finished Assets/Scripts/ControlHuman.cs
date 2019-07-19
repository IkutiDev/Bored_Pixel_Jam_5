using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHuman : MonoBehaviour
{
    [SerializeField] private float runSpeed = 5f;
    private Animator animator;
    private Rigidbody2D _rigidbody2D;
    public enum HumanState
    {
        Stop,
        Walk,
        Run,
        Jump
    }

    public HumanState currentState=HumanState.Stop;
    private static readonly int State = Animator.StringToHash("State");

    private void Awake()
    {
        animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case HumanState.Stop:
                Stop();
                break;
            case HumanState.Walk:
                Walk();
                break;
            case HumanState.Run:
                Run();
                break;
            case HumanState.Jump:
                Jump();
                break;
            default:
                Debug.LogError("Error in the ControlHuman Script");
                break;
        }
    }

    private void Run()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position+runSpeed * Time.fixedDeltaTime  * Vector2.right);
        animator.SetInteger(State, (int)HumanState.Run);
    }

    private void Walk()
    {
        _rigidbody2D.MovePosition(_rigidbody2D.position + Time.fixedDeltaTime * Vector2.right);
        animator.SetInteger(State, (int)HumanState.Walk);
    }

    private void Jump()
    {
        animator.SetInteger(State, (int)HumanState.Jump);
    }

    private void Stop()
    {
        animator.SetInteger(State,(int) HumanState.Stop);
    }
}
